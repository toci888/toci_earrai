import { setDataSynchro } from "../shared/RequestConfig";
import RestClient from "../shared/RestClient";
import CacheModuleService from "./CacheModuleService";


export default class OfflineDataProvider
{
    static cachedProducts = new Array(); // List<ProductDto>
    static fullDbData = new Array();
    static products = new Array();
    restClient = new RestClient();

    cacheModuleService = new CacheModuleService();

    constructor()
    {
        this.cacheModuleService.registerOnlineFunction(this.goOnline);
    }

    static setFullDbData(data) 
    {
        OfflineDataProvider.fullDbData = data;        
    }

    static getProductById(productId)
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

    static getProductsByWorksheetId(worksheetId)
    {
        var result = new Array();

        for(var i = 0; i < OfflineDataProvider.fullDbData.length; i++)
        {
            if(OfflineDataProvider.fullDbData[i].product.idworksheet == worksheetId)
            {
                result.push(OfflineDataProvider.fullDbData[i]);
            }
        }
console.log('count of worksheet products: ', result.length);
        return result;
    }

    static setProductToCache(product)
    {
        OfflineDataProvider.cachedProducts.push(product);
    }

    goOnline()
    {
        // send cachedData to backend and flush them
        this.restClient.POST(setDataSynchro, OfflineDataProvider.cachedProducts);
    }

    GetProducts()
    {
        this.restClient.GET("/api/Synchro/GetProducts").then(res => {products = res; console.log(res);});
    }

    SetProducts(products) 
    {
        this.restClient.POST("/api/Synchro/SetProducts", products);
    }
}