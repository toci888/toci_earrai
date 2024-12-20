import { environment } from "../environment";


export const insertUrl = environment.apiUrl + "api/AreaQuantity/PostAreaQuantities"
export function PostRequestParams(dataToSend_, isCollection = false) {
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

export const updateUrl = environment.apiUrl + "api/AreaQuantity/UpdateAreaQuantity"
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


export function deleteUrl(id_) { return environment.apiUrl + "api/AreaQuantity/" + id_ }

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

export const getProductsEx =  environment.apiUrl + "api/Product/GetProductsEx"

export function getProductUrl(id_) { return environment.apiUrl + 'api/Product/GetProduct/' + id_ }


export function getProductsFromWorksheet(worksheetId, phrase, skip) {
    return environment.apiUrl + "api/Product/GetProducts/" + worksheetId + "/" + phrase + "/" + skip
}

export const getAllWorksheetsUrl = environment.apiUrl + "api/Worksheet/GetAllWorksheetsFromDb"

export function getAllProductsByWorksheet(worksheetId) {
    return environment.apiUrl + "api/Product/GetProducts/" + worksheetId
}

export const getAreasUrl = environment.apiUrl + 'api/Areas'

export function getAreasQuantitiesByProduct(productId) {
    return environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByProduct/' + productId
}

export function getCommisions(productId, price) {
    return environment.apiUrl + 'api/Commisions/GetCommisions?productId=' + productId + '&price=' + price
}

export const addVendorUrl = environment.apiUrl + 'api/QuoteAndPrice/PostQuoteandPrice'

export const getVendorsUrl = environment.apiUrl + 'api/QuoteAndPrice/GetAllVendorsFromDb'

export const getQuoteAndMetricUrl = environment.apiUrl + 'api/QuoteAndMetric'

export function getQuotesAndPricesByProductIdUrl(productId_) {
    return environment.apiUrl + 'api/QuoteAndPrice/QuoteAndPriceByProductId/' + productId_
}

export const getAvailableValuesForSelectedOptionUrl = environment.apiUrl + 'api/Product/GetProductsFiltersEx'
