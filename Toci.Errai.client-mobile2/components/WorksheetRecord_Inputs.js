import { Picker } from '@react-native-community/picker'
import React from 'react'
import { View, TextInput } from 'react-native'
import AppUser from '../shared/AppUser'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

export default function WorksheetRecord_Inputs(props) {

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

            <View style={worksheetRecord.QuantityView}>
                {
                    props.kindOfDisplay == 1 ?
                    (<View style={worksheetRecord.DimensionsView}>

                        <View style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={props.tempAreaquantityRow.length}
                                onChangeText={(text) => setLength(text)}
                                placeholder="Type Length.."
                            />

                        </View>

                        <View style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={props.tempAreaquantityRow.width}
                                onChangeText={(text) => setWidth(text)}
                                placeholder="Type Width.."
                            />

                        </View>

                    </View>)
                    :
                    (<View style={worksheetRecord.DimensionsInputContainerOne}>
                        <TextInput
                            style={worksheetRecord.inputStyle}
                            value={props.tempAreaquantityRow.length}
                            onChangeText={(text) => props.setLength(text)}
                            placeholder="Type Length.."
                        />

                    </View>)
                }

            </View>

            <View style={worksheetRecord.QuantityView}>
                <View style={worksheetRecord.QuantityInputContainer}>
                    <TextInput
                        style={worksheetRecord.inputStyle}
                        value={props.tempAreaquantityRow.quantity}
                        onChangeText={($event) => setAreaquantity($event)}
                        placeholder="Type Quantity.."
                    />

                </View>

            </View>
        </View>
    )
}
