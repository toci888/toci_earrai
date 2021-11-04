import { Picker } from '@react-native-community/picker'
import React, { useState } from 'react'
import { Text, TextInput, View } from 'react-native'
import AppUser from '../../shared/AppUser'
import { addVendorUrl, insertRequestParams } from '../../shared/RequestConfig'
import { Vendors_Inputs_Styles as vI } from './Vendors_Inputs_Styles'

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
        console.log(addVendorUrl)
        console.log(SelectedVendorsHook)
        fetch(addVendorUrl, insertRequestParams(SelectedVendorsHook))
        .then( response_ => {
            console.log(response_)
            props.getAllQuotesAndPricesByProductId()
        }).catch(error_ => {
            console.log(error_)
        })
    }

    return (
        <>
        <View style={{marginTop: 10}}>
            <Text style={{fontSize: 17, padding: 5}}>Add:</Text>
        </View>
        <View style={[vI.container]}>

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

            <View style={vI.okCont} onClick={send}>
                <View style={vI.okFlex}>
                    <View style={vI.ok}>
                        <Text>OK</Text>
                    </View>
                </View>

            </View>

        </View>
        </>
    )
}
