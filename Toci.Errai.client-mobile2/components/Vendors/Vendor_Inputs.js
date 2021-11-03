import { Picker } from '@react-native-community/picker'
import React, { useEffect, useState } from 'react'
import { Text, TextInput, View } from 'react-native'
import AppUser from '../../shared/AppUser'
import { addVendorUrl, insertRequestParams } from '../../shared/RequestConfig'
import { Product_AreaQuantityInputsStyle as aqI } from '../Product_AreaQuantityInputsStyle'
import { Vendor_Inputs_Styles as vI } from './Vendor_Inputs_Styles'

export default function Vendor_Inputs(props) {

    console.log(props)

    const [SelectedVendorsHook, setSelectedVendorsHook] = useState({
        id: 0,
        iduser: AppUser.getId(),
        idproducts: props.productId,
        price: "",
        idvendor: null,
        idquoteandmetric: null,
        createdat: null,
        updatedat: null,
    })

    useEffect(() => {

        //setVendorsHook(AppUser.getVendors())

        /*fetch(addVendor(props.productId, AppUser.getId())).then(response_ => {
            return response_.json()
        }).then(response_ => {
            console.log(response_)

        }).finally(x => {

        })*/

    }, [])

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
        fetch(addVendorUrl, insertRequestParams(SelectedVendorsHook))
        .then( response_ => {
            console.log(response_)
        }).catch(error_ => {
            console.log(error_)
        })
    }

    return (

        <View style={vI.container}>

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

    )
}
