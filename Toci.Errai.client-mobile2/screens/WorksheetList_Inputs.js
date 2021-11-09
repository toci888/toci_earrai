import React from 'react'
import { Pressable, Text, View } from 'react-native'
import { TextInput } from 'react-native-paper'
import WorksheetList_Inputs_DimensionsAB from './WorksheetList_Inputs_DimensionsAB'

const ComponentsTypes = {
    dimensionAB: WorksheetList_Inputs_DimensionsAB,
}

export default function WorksheetList_Inputs(props) {


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
