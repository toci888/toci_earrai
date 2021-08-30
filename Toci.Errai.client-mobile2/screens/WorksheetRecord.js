import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Picker } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])

    useEffect( () => {

        console.log("USE EFFECT")

        connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        setColumnsName(navigation.getParam('worksheetColumns'))
        const x = navigation.getParam('workSheetRecord')


        if(x == null) {
            const newArr = []
            for(let i=0; i < navigation.getParam('worksheetColumns')[0].length; i++) {
                newArr.push(
                    {
                        //id: 190,
                        idworksheet: 1,
                        createdat: new Date().getTime(),
                        updatedat: new Date().getTime(),
                        columnindex: i,
                        rowindex: null
                    }
                )
            }
            setColumnsData(newArr)
        } else {
            setColumnsData(navigation.getParam('workSheetRecord'))
        }

        AsyncStorage.getItem('Categories')
        .then(response => {
            console.log(response);
            //setcategories(response)
        })





        AsyncStorage.getItem('Areas')
        .then(response => {
            response = JSON.parse(response)

            console.log(response);
            setareas(response)
            return response
        })
        .then(response => {
            //console.log(areas);
        })

        return () => {console.log("END RECORD SCREEN ?")}
    }, [] )

    const testChangeValue = (e, index) => {
        console.log(e.target.value, index)


        let val = columnsData[index].value


        const tempContent = [...columnsData]

        //console.log(tempContent)

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

    const setSelectedValue = (item, index) => {
        console.log(item);
    }

    const valueOf = (value) => { return value == "" ? "Empty Value.." : value }

    const valueOfCol = (value) => { return value == "" ? "Empty Column" : value }


    const displayRow = () => {
        if(columnsName.length < 1) return

        let respo = []
        for(let i = 0; i < columnsData.length; i++) {

            respo.push(
                <View key={i} style={ worksheetRecord.rowContainer }>

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
            <View style={ worksheetRecord.absoluteUpdate }>
                <Text style={worksheetRecord.updateText} >
                    {navigation.getParam('rowIndex') == null ? "ADD NEW RECORD" : "UPDATE" }
                </Text>
            </View>
            <View>
                <Picker
                    selectedValue="Choose"
                    style={{ height: 50 }}
                    onValueChange={(itemValue, itemIndex) => setSelectedValue(itemValue, itemIndex)}>
                    {
                        areas.map( (item, index) => {
                            return <Picker.Item key={index} label={item.name} value={item} />
                        } )
                    }

                </Picker>
            </View>
            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}
            <View>

                { displayRow() }

            </View>
        </View>
    )
}
