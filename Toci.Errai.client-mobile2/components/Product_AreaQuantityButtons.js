import React from 'react'
import { Text, View } from 'react-native'
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
            <View style={ productCSSAddBtn.absoluteUpdate }>
                <Text  onPress={ () => sendRequest()} style={productCSSAddBtn.updateText}>
                    { props.btnvalueHook }
                </Text>
            </View>

            { props.btnvalueHook == "UPDATE" && (
                <View>
                    <View style={ productCSSAddBtn.cancelBtn }>
                        <Text onPress={ () => cancel()} style={productCSSAddBtn.deleteText}>
                            CANCEL
                        </Text>
                    </View>
                </View>
            ) }
        </>
    )
} {/* </TouchableOpacity> */} {/* </TouchableOpacity> */}