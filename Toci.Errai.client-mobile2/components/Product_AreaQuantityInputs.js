import { Picker } from '@react-native-community/picker'
import React from 'react'
import { View, TextInput } from 'react-native'
import { TouchableOpacity } from 'react-native-gesture-handler'
import AppUser from '../shared/AppUser'
import { productCSS } from '../styles/Product_Util_Styles'

export default function Product_AreaQuantityInputs(props) {

    const setLength = text => {
        props.settempAreaquantityRow(prev => {
            return {...prev, length: text }
        })
    }

    const setWidth = text => {
        props.settempAreaquantityRow(prev => {
            return {...prev, width: text}
        })
    }

    const setAreaquantity = text => {
        props.settempAreaquantityRow(prev => {
            return {...prev, quantity: text}
        })
    }

    const setAreaFunc = (_id, index) => {
        props.settempAreaquantityRow(prev => {
            return {...prev, idarea: _id}
        })

        AppUser.setIdArea(_id)
    }

    const cancel = () => {
        props.setbtnvalueHook("ADD")
    }

    return (
        <View>
            <View style={productCSS.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={productCSS.ComboPicker}
                    selectedValue={props.tempAreaquantityRow.idarea}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        props.areas.map( (item, index) => {
                            return <Picker.Item style={productCSS.CombiItem} key={index} label={item.name} value={item.id} />
                        } )
                    }

                </Picker>
            </View>

            <View style={productCSS.QuantityView}>
                {
                    props.kindOfDisplay != 1 ?
                    (<View style={productCSS.DimensionsView}>

                        <View style={productCSS.DimensionsInputContainerTwo}>
                            <TextInput
                                style={productCSS.inputStyle}
                                value={props.tempAreaquantityRow.length}
                                onChangeText={(text) => setLength(text)}
                                placeholder="Type Length.."
                            />

                        </View>

                        <View style={productCSS.DimensionsInputContainerTwo}>
                            <TextInput
                                style={productCSS.inputStyle}
                                value={props.tempAreaquantityRow.width}
                                onChangeText={(text) => setWidth(text)}
                                placeholder="Type Width.."
                            />

                        </View>

                    </View>)
                    :
                    (<View style={productCSS.DimensionsInputContainerOne}>
                        <TextInput
                            style={productCSS.inputStyle}
                            value={props.tempAreaquantityRow.length}
                            onChangeText={(text) => props.setLength(text)}
                            placeholder="Type Length.."
                        />

                    </View>)
                }

            </View>

            <View style={productCSS.QuantityView}>
                <View style={productCSS.QuantityInputContainer}>
                    <TextInput
                        style={productCSS.inputStyle}
                        value={props.tempAreaquantityRow.quantity}
                        onChangeText={($event) => setAreaquantity($event)}
                        placeholder="Type Quantity.."
                    />

                </View>

            </View>

        </View>
    )
}
