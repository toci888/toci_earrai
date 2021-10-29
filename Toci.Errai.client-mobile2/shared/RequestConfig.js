import { environment } from "../environment";


export const insertUrl = environment.apiUrl + "api/AreaQuantity/PostAreaQuantities"
export function insertRequestParams(dataToSend_) {
    const x = JSON.parse(JSON.stringify(dataToSend_))

    return {
        method: "POST",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify([x]) // arequantity
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


export function getProductUrl(id_) { return environment.apiUrl + 'api/Product/GetProduct/' + id_ }


export function getProductsFromWorksheet(worksheetId, phrase, skip) {
    return environment.apiUrl + "api/Product/GetProducts/" + worksheetId + "/" + phrase + "/" + skip
}

export const getAllWorksheetsUrl = environment.apiUrl + "api/Worksheet/GetAllWorksheetsFromDb"

export const getAreasUrl = environment.apiUrl + 'api/Areas'

export function getAreasQuantitiesByProduct(productId) {
    return environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByProduct/' + productId
}