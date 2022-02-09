import React from 'react'
import { Alert, Text, View } from 'react-native'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { insertUrl, PostRequestParams, updateRequestParams, updateUrl } from '../shared/RequestConfig'
import { productCSSAddBtn } from '../styles/Product_AreaQuantityButtonsStyles'
import RestClient from '../shared/RestClient'

export default function Product_AreaQuantityButtons(props) {

    let restClient = new RestClient();

    const sendRequest = () => {
        console.log(2)
        // TODO validate inputs
        props.setloading(true)
        let url, requestParams
        if(props.btnvalueHook == "ADD") { url = insertUrl; requestParams = PostRequestParams
        } else { url = updateUrl; requestParams = updateRequestParams }

        restClient.PUT(url, requestParams(props.tempAreaquantityRow, true)).then( x => {
            console.log(x);
            props.updateAreaQuantitiesfterRequest();
            props.initAreaQuantities();
        }).catch(error => {
            console.log(error)
            Alert.alert("Error", "Something went wrong", [ { onPress: () => console.log("OK") } ]);
            props.setloading(false);
        });
    }

    const cancel = () => {
        props.setbtnvalueHook("ADD")
        props.initAreaQuantities()
    }

    return (
        <>
            <View>
                <TouchableOpacity onPress={ () => sendRequest()}>
                    <View style={ productCSSAddBtn.absoluteUpdate }>
                        <Text style={productCSSAddBtn.updateText}>
                            { props.btnvalueHook }
                        </Text>
                    </View>
                </TouchableOpacity>
            </View>

            { props.btnvalueHook == "UPDATE" && (
                <View>
                    <TouchableOpacity onPress={ () => cancel()}>
                        <View  style={ productCSSAddBtn.cancelBtn }>
                            <Text style={productCSSAddBtn.deleteText}>
                                CANCEL
                            </Text>
                        </View>
                    </TouchableOpacity>
                </View>
            ) }
        </>
    )
}