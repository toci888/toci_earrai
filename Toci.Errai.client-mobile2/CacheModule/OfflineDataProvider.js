import { setDataSynchro } from "../shared/RequestConfig";
import RestClient from "../shared/RestClient";
import CacheModuleService from "./CacheModuleService";


export default class OfflineDataProvider
{
    static cachedProducts = new Array(); // List<ProductDto>
    static fullDbData = new Array();
    restClient = new RestClient();

    cacheModuleService = new CacheModuleService();

    constructor()
    {
        this.cacheModuleService.registerOnlineFunction(this.goOnline);
    }

    setFullDbData(data) 
    {
        fullDbData = data;        
    }

    getProductById(productId)
    {
        for(i = 0; i < OfflineDataProvider.fullDbData.length; i++)
        {
            if (OfflineDataProvider.fullDbData[i].product.id == productId)
            {
                return OfflineDataProvider.fullDbData[i];
            }
        }

        return null;
    }

    getProductsByWorksheetId(worksheetId)
    {
        result = new Array();

        for(i = 0; i < OfflineDataProvider.fullDbData.length; i++)
        {
            if(OfflineDataProvider.fullDbData[i].product.idworksheet == worksheetId)
            {
                result.push(OfflineDataProvider.fullDbData[i]);
            }
        }

        return result;
    }

    setProductToCache(product)
    {
        OfflineDataProvider.cachedProducts.push(product);
    }

    goOnline()
    {
        // send cachedData to backend and flush them
        this.restClient.POST(setDataSynchro, OfflineDataProvider.cachedProducts);
    }

    
}