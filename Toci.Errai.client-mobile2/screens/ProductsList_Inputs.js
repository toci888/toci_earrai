import React from 'react'
import { Pressable, Text, View } from 'react-native'
import { TextInput } from 'react-native-paper'
import ProductsList_Inputs_DimensionsAB from './ProductsList_Inputs_DimensionsAB'

const ComponentsTypes = {
    dimensionAB: ProductsList_Inputs_DimensionsAB,
}

export default function ProductsList_Inputs(props) {


    return (
        <View style={ps.filterContent}>
            <TextInput
                value={filteredValue}
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
    )
}
