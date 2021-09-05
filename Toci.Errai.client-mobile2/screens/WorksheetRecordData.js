import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput } from 'react-native'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

export default function WorksheetRecordData(props) {


    const valueOfCol = (value) => { return value == "" ? "Empty Column" : value }

    const displayRow = () => {
        if(props.columnsName.length < 1) return

        let respo = []
        for(let i = 0; i < columnsData.length; i++) {

            respo.push(
                <View key={i} style={ worksheetRecord.rowContainer }>

                    <View style={worksheetRecord.columns}>
                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(props.columnsName[0][i].value)}</Text>
                        </View>

                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(props.columnsName[1][i].value)}</Text>
                        </View>
                    </View>

                    <View key={i + "x"} style={worksheetRecord.value}>
                        <Text>
                            {columnsData[i].value}
                        </Text>
                    </View>

                </View>
            )
        }

        return respo
    }

    return(

        <View>
            { displayRow() }
        </View>
    )
}