import { Picker } from '@react-native-community/picker'
import React from 'react'
import { Text, View, TextInput } from 'react-native'
import AppUser from '../shared/AppUser'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

export default function WorksheetRecord_Inputs(props) {

    console.log(props)

    const setLength = text => {
        props.settempAreaquantityRow(prev => {
            return {...prev, lengthdimensions: text }
        })
    }

    const setWidth = text => {
        props.settempAreaquantityRow(prev => {
            return {...prev, widthdimensions: text}
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
            <View style={worksheetRecord.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={worksheetRecord.ComboPicker}
                    selectedValue={props.tempAreaquantityRow.idarea}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        props.areas.map( (item, index) => {
                            return <Picker.Item style={worksheetRecord.CombiItem} key={index} label={item.name} value={item.id} />
                        } )
                    }

                </Picker>
            </View>

            <View>
                {
                    props.kindOfDisplay == 1 ?
                    (<View style={worksheetRecord.DimensionsView}>

                        <View style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={globalStyles.inputStyle}
                                value={props.tempAreaquantityRow.lengthdimensions}
                                onChangeText={(text) => setLength(text)}
                                placeholder="Type Length.."
                            />

                        </View>

                        <View style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={globalStyles.inputStyle}
                                value={props.tempAreaquantityRow.widthdimensions}
                                onChangeText={(text) => setWidth(text)}
                                placeholder="Type Width.."
                            />

                        </View>

                    </View>)
                    :
                    (<View style={worksheetRecord.DimensionsInputContainerOne}>
                        <TextInput
                            style={globalStyles.inputStyle}
                            value={props.tempAreaquantityRow.lengthdimensions}
                            onChangeText={(text) => props.setLength(text)}
                            placeholder="Type Length.."
                        />

                    </View>)
                }

            </View>

            <View style={worksheetRecord.DimensionsView}>
                <View style={worksheetRecord.QuantityInputContainer}>
                    <TextInput
                        style={globalStyles.inputStyle}
                        value={props.tempAreaquantityRow.quantity}
                        onChangeText={($event) => setAreaquantity($event)}
                        placeholder="Type Quantity.."
                    />

                </View>

            </View>
        </View>
    )
}
