import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Button, Text, View, TextInput } from 'react-native'
import { DataTable } from 'react-native-paper'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'

let tempColumns = 6

let testValues = ["hehe", "dupa1", "xD", "Bartłomiej"]

export default function WorksheetContent({ route, navigation }) {


    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [columns, setColumns] = useState(() => [])
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect(() => {

        fetch("https://localhost:44326/api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId'))
            .then(response => response.json())
            .then(response => {
                console.log(response)
                setColumns(response)
                setloading(false)
            })

    }, [])

    const searchForData = () => {
        fetch("https://localhost:44326/api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue)
        .then(response => response.json())
        .then(response => {
            console.log(response)
            setworksheetContent(response)
        })
    }

    const showRecordData = (rowIndex) => {

        console.log(worksheetContent[rowIndex])


        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            workSheetRecord: worksheetContent[rowIndex],
            connectService: connectService
        })



    }


    const filterContent = (e) => {

        console.log(e.target.value);
        setfilteredValue(e.target.value)

        if(e.target.value.length < 3) return

        searchForData()

        //let filtered = worksheetContent.filter(item => item.name.toLowerCase().includes(e.target.value.toLowerCase()))
        //setdisplayedworksheetContent(filtered)
    }

    const testChangeValue = (rowIndex, columnIndex) => {
        console.log(rowIndex, columnIndex)

        let random = Math.floor(Math.random() * (testValues.length - 0)) + 0

        let val = testValues[random]


        const tempContent = [...worksheetContent]
        console.log(tempContent)

        tempContent[rowIndex][columnIndex].value = val
        console.log(connectService.isConnectedFunc())
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(tempContent[rowIndex][columnIndex])
        } else {
            connectService.updateRecord(tempContent[rowIndex][columnIndex])
        }

        setworksheetContent(tempContent)

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    if (loading) {
        return (
            <View style={globalStyles.loading}>
                <Text style={globalStyles.loadingText}>Loading..</Text>
            </View>
        )
    }

    return (
        <View style={globalStyles.content}>
            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}

            <Text style={globalStyles.chooseWorkbookHeader}> Worksheet Content (Table) </Text>

            <View>

                <TextInput
                    value={filteredValue}
                    style={globalStyles.inputStyle}
                    onChange={($event) => filterContent($event)}
                    placeholder="Filter.."
                />

            </View>

            <View>

                <DataTable>

                    {/* Chwilowo tylko kilka column widocznych */}

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns[0].map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns[1].map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                        })}

                    </DataTable.Header>

                    {
                        worksheetContent.map( (row, rowIndex) => {
                            return(<DataTable.Row key={ rowIndex } >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    return <DataTable.Cell
                                                key={column.id}
                                                onPress={ () => showRecordData(rowIndex) }
                                                // onPress={ () => testChangeValue(rowIndex, columnIndex) }
                                                style={globalStyles.cell}>
                                                {column.value}
                                            </DataTable.Cell>
                                } ) }
                            </DataTable.Row>)
                        } )
                    }

                </DataTable>

            </View>
            <View style={{paddingTop: 45}}>
                <Button title="ADD NEW RECORD" />
            </View>

        </View>
    )
}
