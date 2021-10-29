import React from 'react'
import { worksheetRecordAddBtn } from '../styles/Product_AreaQuantityButtonsStyles'
import { Text, View } from 'react-native'
import { environment } from '../environment'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { insertUrl, insertRequestParams, updateRequestParams, updateUrl } from '../shared/RequestConfig'

export default function Product_AreaQuantityButtons(props) {

    const sendRequest = () => {

        // TODO validate inputs
        props.setloading(true)
        let url, requestParams
        if(props.btnvalueHook == "ADD") { url = insertUrl; requestParams = insertRequestParams
        } else { url = updateUrl; requestParams = updateRequestParams }

        fetch(url, requestParams(props.tempAreaquantityRow)).then( response => {
            console.log(response)
            props.updateAreaQuantitiesfterRequest()
            props.initAreaQuantities()
        }).catch(error => {
            console.log(error)
        })
    }

    const cancel = () => {
        props.setbtnvalueHook("ADD")
        props.initAreaQuantities()
    }

    return (
        <>
            <View style={ worksheetRecordAddBtn.absoluteUpdate }>
                <Text  onPress={ () => sendRequest()} style={worksheetRecordAddBtn.updateText}>
                    { props.btnvalueHook }
                </Text>
            </View>

            { props.btnvalueHook == "UPDATE" && (
                <View>
                    <View style={ worksheetRecordAddBtn.cancelBtn }>
                        <Text onPress={ () => cancel()} style={worksheetRecordAddBtn.deleteText}>
                            CANCEL
                        </Text>
                    </View>
                </View>
            ) }
        </>
    )
} {/* </TouchableOpacity> */} {/* </TouchableOpacity> */}