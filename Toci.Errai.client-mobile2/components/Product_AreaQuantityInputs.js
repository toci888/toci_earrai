import { Picker } from '@react-native-community/picker'
import React from 'react'
import { View, TextInput, Text } from 'react-native'
import AppUser from '../shared/AppUser'
import { Product_AreaQuantityInputsStyle as p } from './Product_AreaQuantityInputsStyle';
import LengthsWidthsCache from '../CacheModule/LengthsWidthsCache';
//import * as Localization from 'expo-localization';

export default function Product_AreaQuantityInputs(props) {

    const metrics = worksheetId => {
        if (worksheetId < 4) {
            return ' (mm) ';
        }
        else
        {
            return ' (m)';
        }
    }
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



    return (
        <View>

            <View style={p.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={p.ComboPicker}
                    selectedValue={props.tempAreaquantityRow.idarea}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        props.areas.map( (item, index) => {
                            return <Picker.Item style={p.CombiItem} key={index} label={item.name} value={item.id} />
                        } )
                    }

                </Picker>
            </View>

            <View>

                <View style={p.DimensionsView}>

                    <View style={p.dimensionContainer}>
                        <View style={p.labelFlex}>
                            <Text style={p.labelLetter}>L{metrics(AppUser.getWorksheetId())}</Text>
                        </View>
                            <View style={p.inputFlex}>
                                {/* <TouchableOpacity style={{width: '100%'}}> */}
                                <TextInput keyboardType="phone-pad"
                                    style={p.inputStyle}
                                    value={props.tempAreaquantityRow.length}
                                    onChangeText={(entryValue) => { setLength(entryValue.replace(',', '.')); }}
                                    placeholder="Type Length.."
                                />
                                {/* </TouchableOpacity> */}
                            </View>


                    </View>

                    { LengthsWidthsCache.GetCodeDimentionKind(LengthsWidthsCache.categoryPrefix) == 1 && 
                    <View style={p.dimensionContainer}>
                        <View style={p.labelFlex}>
                            <Text style={p.labelLetter}>W{metrics(AppUser.getWorksheetId())}</Text>
                        </View>
                        <View style={p.inputFlex}>
                            <TextInput
                            keyboardType= "phone-pad"
                                style={p.inputStyle}
                                value={props.tempAreaquantityRow.width}
                                onChangeText={(entryValue) => {
                                 
                                      setWidth(entryValue.replace(',', '.'))}}
                               
                                placeholder="Type Width.."
                            />
                        </View>
                    </View>
                    }

                    <View style={p.dimensionContainer}>

                        <View style={p.labelFlex}>
                            <Text style={p.labelLetter}>Q</Text>
                        </View>
                        <View style={p.inputFlex}>
                            <TextInput
                            keyboardType="phone-pad"
                                style={p.inputStyle}
                                value={props.tempAreaquantityRow.quantity}
                                onChangeText={(entryValue) => { setAreaquantity(entryValue.replace(',', '.'))}}
                                placeholder="Type Quantity.."
                            />

                        </View>

                    </View>

                </View>

            </View>

        </View>
    )
}
