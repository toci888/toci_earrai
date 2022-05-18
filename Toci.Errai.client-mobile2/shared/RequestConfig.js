import { environment } from "../environment";


export const insertUrl = "api/AreaQuantity/PostAreaQuantities"

export const updateUrl = "api/AreaQuantity/UpdateAreaQuantity";

export function updateRequestParams(dataToSend_) {
    const x = JSON.parse(JSON.stringify(dataToSend_))
    return {
        method: "PUT",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(x) // arequantity
    }

}

export function PostRequestParams(dataToSend_, isCollection = true) {
    const json_ = JSON.parse(JSON.stringify(dataToSend_))

    const toSend = isCollection ? [json_] : json_

    return {
        method: "POST",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(toSend) // arequantity
    }
}

export function deleteUrl(id_) { return "api/AreaQuantity/" + id_ }

export function deleteRequestParams(dataToSend_) {
    return {
        method: "DELETE",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify([dataToSend_])
    }
}

export const getProductsEx =  "api/Product/GetProductsEx"

export function getProductUrl(id_) { return 'api/Product/GetProduct/' + id_ }


export function getProductsFromWorksheet(worksheetId, phrase, skip) {
    return environment.apiUrl + "api/Product/GetProducts/" + worksheetId + "/" + phrase + "/" + skip
}

export const getAllWorksheetsUrl = "api/Worksheet/GetAllWorksheetsFromDb"

export function getAllProductsByWorksheet(worksheetId) {
    return "api/Product/GetProducts/" + worksheetId + "?IsMobileRequest=true"
}

export const getAreasUrl = 'api/Areas';

export function getAreasQuantitiesByProduct(productId) {
    return 'api/AreasQuantities/GetAreasQuantitiesByProduct/' + productId;
}

// export function getCommisions(productId, price) {
//     return environment.apiUrl + 'api/Commisions/GetCommisions?productId=' + productId + '&price=' + price
// }

export const addVendorUrl = 'api/QuoteAndPrice/PostQuoteandPrice'

export const getVendorsUrl = 'api/QuoteAndPrice/GetAllVendorsFromDb';

export const getQuoteAndMetricUrl = 'api/QuoteAndMetric'

export function getQuotesAndPricesByProductIdUrl(productId_) {
    return 'api/QuoteAndPrice/QuoteAndPriceByProductId/' + productId_
}

export const getAvailableValuesForSelectedOptionUrl = 'api/Product/GetProductsFiltersEx'
