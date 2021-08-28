import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

export default function WorksheetRecord({ route, navigation }) {

    console.log(navigation.getParam('worksheetColumns'))
    console.log(navigation.getParam('workSheetRecord'))
    console.log(navigation.getParam('connectService'))

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])

    useEffect( () => {

        console.log("USE EFFECT")

        setColumnsName(navigation.getParam('worksheetColumns'))
        setColumnsData(navigation.getParam('workSheetRecord'))


    }, [] )

    const testChangeValue = (e, index) => {
        console.log(e.target.value, index)


        let val = columnsData[index].value


        const tempContent = [...columnsData]

        console.log(tempContent)

        tempContent[index].value = e.target.value



        setColumnsData(tempContent)
        return

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const updateValue = (index) => {

        const tempContent = columnsData[index]

        console.log(columnsData[index])
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(tempContent)
        } else {
            connectService.updateRecord(tempContent)
        }
    }

    const valueOf = (value) => { return value == "" ? "Empty Value.." : value }

    const valueOfCol = (value) => { return value == "" ? "Empty Column" : value }


    const displayRow = () => {
        if(columnsName.length < 1) return

        let respo = []
        for(let i = 0; i < columnsData.length; i++) {

            respo.push(
                <View key={i} style={ worksheetRecord.rowContainer }>
                    <View style={ worksheetRecord.absoluteUpdate }>
                        <Text>UPDATE</Text>
                    </View>

                    <View style={worksheetRecord.columns}>
                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[0][i].value)}</Text>
                        </View>

                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[1][i].value)}</Text>
                        </View>
                    </View>

                    <View key={i + "x"} style={worksheetRecord.value}>
                        <Text>

                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={columnsData[i].value}
                                onChange={($event) => testChangeValue($event, i)}
                            />

                        </Text>

                        {/* <Text style={worksheetRecord.updateButtonContainer}
                            onPress={ () => updateValue(i) }>
                            UPDATE
                        </Text> */}

                    </View>

                </View>
            )

            //respo.push()  style={{width: '85%'}}

        }

        return respo
    }

    return (
        <View style={worksheetRecord.container}>
            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}
            <View>

                { displayRow() }

            </View>
        </View>
    )
}
