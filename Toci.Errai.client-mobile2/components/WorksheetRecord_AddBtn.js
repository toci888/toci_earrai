import React from 'react'
import { worksheetRecordAddBtn } from '../styles/worksheetRecordAddBtnStyles'
import { Text, View } from 'react-native'
import { environment } from '../environment'

export default function WorksheetRecord_AddBtn(props) {

    const sendRequest = () => {

        let dataToSend = JSON.parse(JSON.stringify(props.tempAreaquantityRow));

        // TODO validate inputs
        props.setloading(true)
        if(props.btnvalueHook == "ADD") {

            fetch(environment.prodApiUrl + "api/AreaQuantity/PostAreaQuantities", {
                method: "POST",
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify([dataToSend]) // arequantity
            }).then( response => {
                console.log(response);
                props.updateTableAfterRequest()
                props.clearInputs()
            }).catch(error => {
                console.log(error)
            }).finally(x => {
                props.setloading(false)
            })

        } else if(props.btnvalueHook == "UPDATE") {

            fetch(environment.prodApiUrl + "api/AreaQuantity/UpdateAreaQuantity", {
                method: "PUT",
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(dataToSend) // arequantity
            }).then( response => {
                props.updateTableAfterRequest()
                props.clearInputs()
            }).catch(error => {
                console.log(error)
            }).finally(x => {
                props.setloading(false)
            })

        }
    }

    return (
        <View style={ worksheetRecordAddBtn.absoluteUpdate }>

            <Text style={worksheetRecordAddBtn.updateText} onPress={ () => sendRequest() } >
                { props.btnvalueHook }
            </Text>
        </View>
    )
}
