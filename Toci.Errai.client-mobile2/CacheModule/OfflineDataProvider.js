import { setDataSynchro } from "../shared/RequestConfig";
import RestClient from "../shared/RestClient";
import CacheModuleService from "./CacheModuleService";


export default class OfflineDataProvider
{
    static cachedProducts = new Array(); // List<ProductDto>
    restClient = new RestClient();

    cacheModuleService = new CacheModuleService();

    constructor()
    {
        this.cacheModuleService.registerOnlineFunction(this.goOnline);
    }

    goOnline()
    {
        // send cachedData to backend and flush them
        this.restClient.POST(setDataSynchro, OfflineDataProvider.cachedProducts);
    }

    cacheProduct(product) // ? receive either number of parameters and combine them into product dto, or have a ready product dto
    {

    }
}