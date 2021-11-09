import React, { useState } from 'react'
import { Pressable, Text, View } from 'react-native'
import { TextInput } from 'react-native-paper'
import { Picker } from '@react-native-community/picker'
import { typesOfSearch } from './WorksheetListConfig'
import { ProductStyle as ps } from '../styles/ProductStyle'

export default function WorksheetList_Inputs_DimensionsAB() {


    const [FilteredTextHook, setFilteredTextHook] = useState("")


    const setFilterText = (text) => {
        setFilteredTextHook(text)
    }

    const filterContent = () => {

    }


    return (
        <>
            <View style={ps.filterContent}>
                <TextInput
                    value={FilteredTextHook}
                    style={ps.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter.."
                />
                <View style={ps.filterButtonView}>
                    <Pressable style={ps.filterButton} onPress={filterContent}>
                        <Text style={ps.textUpdate}>Find</Text>
                    </Pressable>
                </View>

            </View>

            <View style={p.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={p.ComboPicker}
                    selectedValue={props.tempAreaquantityRow.idarea}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        typesOfSearch.map( (item, index) => {
                            return <Picker.Item style={p.CombiItem} key={index} label={item} value={item} />
                        } )
                    }

                </Picker>
            </View>
        </>
    )
}
