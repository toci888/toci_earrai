import { environment } from "../environment";


export const insertUrl = environment.apiUrl + "api/AreaQuantity/PostAreaQuantities"
export function insertRequestInfo(dataToSend_) {

    return {
        method: "POST",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify([dataToSend_]) // arequantity
    }

}


export const updateUrl = environment.apiUrl + "api/AreaQuantity/UpdateAreaQuantity"
export function updateRequestInfo(dataToSend_) {
    return {
        method: "PUT",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSend_) // arequantity
    }

}