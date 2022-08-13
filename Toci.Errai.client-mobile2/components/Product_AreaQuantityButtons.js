import React from 'react'
import { Alert, Text, View } from 'react-native'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { insertUrl, updateUrl } from '../shared/RequestConfig'
import { productCSSAddBtn } from '../styles/Product_AreaQuantityButtonsStyles'
import RestClient from '../shared/RestClient';
import OfflineDataProvider from '../CacheModule/OfflineDataProvider';
import { checkConnected } from '../shared/isConnected';

export default function Product_AreaQuantityButtons(props) {

    let restClient = new RestClient();

    const sendRequest = () => {

        if(props.tempAreaquantityRow.length == "" || props.tempAreaquantityRow.quantity == "" || props.tempAreaquantityRow.width == "") {
            Alert.alert("Form not filled", "Please fill in the form");
            return;
        }

        // TODO validate inputs
        props.setloading(true)

        //checkConnected(saveAreaQuantity, props.tempAreaquantityRow);

        if(props.btnvalueHook == "Add") { 
            restClient.POST(insertUrl, [props.tempAreaquantityRow]).then( x => {
                props.updateAreaQuantitiesfterRequest("Added new area Quantities");
                props.initAreaQuantities();
            }).catch(error => {
                console.log(error)
                Alert.alert("Error", "Something went wrong", [ { onPress: () => console.log("OK") } ]);
                props.setloading(false);
            });
        } else { 
            restClient.PUT(updateUrl, props.tempAreaquantityRow).then( x => {
                props.updateAreaQuantitiesfterRequest("Updated area Quantities");
                props.initAreaQuantities();
            }).catch(error => {
                console.log(error)
                Alert.alert("Error", "Something went wrong", [ { onPress: () => console.log("OK") } ]);
                props.setloading(false);
            });
        }
    }

    const postAreaQuantity = (areaQuantity) => 
    {
        restClient.POST(insertUrl, areaQuantity).then( x => {
            props.updateAreaQuantitiesfterRequest("Added new area Quantities");
            props.initAreaQuantities();
        }).catch(error => {
            console.log(error)
            Alert.alert("Error", "Something went wrong", [ { onPress: () => console.log("OK") } ]);
            props.setloading(false);
        }).finally()
        {
            props.setloading(false);
        };
    }

    const cacheAddAreaQuantity = (areaQuantity) => 
    {
        console.log('caching areas quantity', areaQuantity); // todo

        props.setloading(false);
    }

    const saveAreaQuantity = (isConnected, areaQuantity) => 
    {
        if (isConnected)
        {
            postAreaQuantity(areaQuantity);
        }
        else
        {
            cacheAddAreaQuantity(areaQuantity);
        }
    }

    const cancel = () => {
        props.setbtnvalueHook("Add")
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