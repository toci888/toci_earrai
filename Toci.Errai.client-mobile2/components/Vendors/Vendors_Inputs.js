import { Picker } from '@react-native-community/picker'
import React, { useState } from 'react'
import { Alert, Text, TextInput, View, Modal } from 'react-native'
import AppUser from '../../shared/AppUser'
import { addVendorUrl, insertRequestParams } from '../../shared/RequestConfig'
import { Vendors_Inputs_Styles as vI } from './Vendors_Inputs_Styles'
import { TouchableOpacity } from 'react-native-gesture-handler'

export default function Vendor_Inputs(props) {


    const [SelectedVendorsHook, setSelectedVendorsHook] = useState({
        id: 0,
        idproducts: AppUser.getProductId(),
        rowindex: 0,
        price: "",
        idvendor: 2,
        idquoteandmetric: 2,
        iduser: AppUser.getId(),
    })

    const setVendor = (value_, index_) => {
        setSelectedVendorsHook( prev => {
            return {
                ...prev,
                idvendor: AppUser.getVendors()[index_].id
            }
        })
    }

    const setMetric = (value_, index_) => {
        setSelectedVendorsHook( prev => {
            return {
                ...prev,
                idquoteandmetric: AppUser.getVendors()[index_].id
            }
        })
    }

    const setPrice = (value_) => {
        setSelectedVendorsHook( prev => {
            return {
                ...prev,
                price: value_
            }
        })
    }

    const send = () => {

        let logName, message

        console.log(addVendorUrl)
        console.log(SelectedVendorsHook)
        fetch(addVendorUrl, insertRequestParams(SelectedVendorsHook))
        .then( response_ => {
            console.log(response_)
            props.getAllQuotesAndPricesByProductId()
            logName = "Ok"; message = "Added new Record"
        }).catch(error_ => {
            console.log(error_)
            logName = "Error"; message = "Something went wrong"
        }).finally( () => {
            Alert.alert(
                logName,
                message,
                [ { onPress: () => console.log("OK") }]
            )
        })
    }

    return (
        <>
        {/* <Modal
            visible={SnackHook.type != null}
            onRequestClose={ () => setSnackHook({type: null, message: null}) }
            transparent
        >
            <View>
            <Text>HEJ</Text>
            </View>
        </Modal> */}
        <View style={{marginTop: 10}}>
            <Text style={{fontSize: 17, padding: 5}}>Add:</Text>
        </View>
        <View style={[vI.container, {marginRight: 5}]}>

            <View style={vI.vendorPickerCont}>
                <View style={vI.ComboView}>
                    <Picker
                        selectedValue={SelectedVendorsHook?.idvendor || "Choose"}
                        style={vI.ComboPicker}
                        onValueChange={(itemValue, itemIndex) => setVendor(itemValue, itemIndex)}>
                        {
                            AppUser.getVendors().map( (item, index) => {
                                return <Picker.Item style={vI.CombiItem} key={index} label={item.name} value={item.id} />
                            })
                        }

                    </Picker>
                </View>

            </View>

            <View style={vI.metricPickerCont}>
                <View style={vI.ComboView}>
                    <Picker
                        selectedValue={SelectedVendorsHook?.idquoteandmetric || "Choose"}
                        style={vI.ComboPicker}
                        onValueChange={(itemValue, itemIndex) => setMetric(itemValue, itemIndex)}>
                        {
                            AppUser.getMetrics().map( (item, index) => {
                                return <Picker.Item style={vI.CombiItem} key={index} label={item.valuation} value={item.id} />
                            })
                        }

                    </Picker>
                </View>
            </View>

            <View style={vI.priceCont}>
                <View style={vI.priceFlex}>
                    <TextInput
                        style={vI.inputStyle}
                        value={SelectedVendorsHook?.price}
                        onChangeText={(text) => setPrice(text)}
                        placeholder="Price.."
                    />
                </View>
            </View>

            <View style={vI.okCont}>
                <TouchableOpacity onPress={ () => send()}>
                    <View style={[vI.okFlex, vI.ok]}>
                        <Text style={vI.ok}>
                            OK
                        </Text>
                    </View>
                </TouchableOpacity>
            </View>

        </View>
        </>
    )
}
