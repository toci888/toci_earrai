import React, { useState } from 'react'
import { Pressable, Text, View } from 'react-native'
import { ProductStyle as ps } from '../styles/ProductStyle'

export default function ProductsList_Inputs_DimensionsAB() {


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


        </>
    )
}
