import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Button, Text, View, TextInput } from 'react-native'
import { DataTable } from 'react-native-paper'
import { worksheetContent as worksheetContentCSS } from '../styles/worksheetContent'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment';


let tempColumns = 6

let testValues = ["hehe", "dupa1", "xD", "Bartłomiej"]

export default function WorksheetContent({ route, navigation }) {


    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [columns, setColumns] = useState(() => [])
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect(() => {
        connectService.setNowWorksheetId(navigation.getParam('worksheetId'))

        AsyncStorage.getItem('Worksheetcontents')
        .then(response => {
            //console.log(response);
            console.log(JSON.parse(response))
            let x = JSON.parse(response)
            x = x.filter(item => item.idworksheet == navigation.getParam('worksheetId')
                                && (item.rowindex == 0 || item.rowindex == 1) )
            x = [[...x.slice(0, (x.length / 2))], [...x.slice(x.length / 2)]]
            console.log(x)
            return x
        })
        .then(response => {
            console.log(response)
            setColumns(response)
            setloading(false)
        })

        // fetch(environment.apiUrl + "api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId'))
        //     .then(response => response.json())
        //     .then(response => {
        //         console.log(response)
        //         //console.log(JSON.stringify(response))
        //         setColumns(response)
        //         setloading(false)
        //     }).catch(error => {
        //         console.log(error)

        //     })
            return () => {console.log("GARBAGE");}
    }, [])

    const searchForData = () => {

        AsyncStorage.getItem('Worksheetcontents')
        .then(response => {
            //console.log(response);
            console.log(JSON.parse(response));
            response = JSON.parse(response)
            let x = response.filter(item => item.idworksheet == navigation.getParam('worksheetId')
                                && item.rowindex > 1 && item.value.includes(filteredValue) )
            console.log(x)

            let rows = []

            let returnList = []

            x.forEach(element => {
                if(!rows.includes(element.rowindex)) rows.push(element.rowindex)
            })

            let tempRow

            rows.forEach(tempRow_ => {
                tempRow = []
                let tempRows = response.filter(item =>
                    item.rowindex == tempRow_ &&
                    item.idworksheet == navigation.getParam('worksheetId'))

                tempRows.forEach(element => {
                    tempRow.push(element)
                });

                returnList.push(tempRow)
            });

            console.log(returnList);

            return returnList
        })
        .then(response => {
            //console.log(response);
            setworksheetContent(response)
        })

        /*fetch(environment.apiUrl + "api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue)
        .then(response => response.json())
        .then(response => {
            console.log(response)
            //console.log(JSON.stringify(response))
            setworksheetContent(response)
        }).catch(error => {
            console.log(error)


        })*/
    }

    const showRecordData = (rowIndex) => {

        console.log(worksheetContent[rowIndex])


        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            rowIndex: rowIndex,
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

    const addNewRecord = () => {
        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            workSheetRecord: null,
            connectService: connectService
        })
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
            <View style={worksheetContentCSS.addNewRecordView}>
                <Text style={worksheetContentCSS.addNewRecordBtn} onPress={addNewRecord}> ADD NEW RECORD </Text>
            </View>

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

                <DataTable style={globalStyles.tableContainer}>

                    {/* Chwilowo tylko kilka column widocznych */}

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[0]?.map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[1]?.map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                        })}

                    </DataTable.Header>

                    {
                        worksheetContent?.map( (row, rowIndex) => {
                            console.log(row)
                            return(<DataTable.Row key={ rowIndex } style={worksheetContentCSS.customRow} >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    return <DataTable.Cell
                                                class="dupa"
                                                key={column.id}
                                                onPress={ () => showRecordData(rowIndex) }
                                                // onPress={ () => testChangeValue(rowIndex, columnIndex) }
                                                style={worksheetContentCSS.cell}>
                                                {column.value}
                                            </DataTable.Cell>
                                } ) }
                            </DataTable.Row>)
                        } )
                    }

                </DataTable>

            </View>


        </View>
    )
}
