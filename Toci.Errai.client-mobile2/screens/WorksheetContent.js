import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput } from 'react-native'
import { worksheetContent as worksheetContentCSS } from '../styles/worksheetContent'
import { DataTable } from 'react-native-paper'
import { environment } from '../environment'

let tempColumns = 6

export default function WorksheetContent({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    //const [columns, setColumns] = useState([[], []])
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)

    const [columns, setColumns] = useState([[],[]])

    useEffect(() => {
        let x2 = environment.prodApiUrl + "api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId')
        console.log(x2)
        fetch(x2)
        .then(response => response.json())
        .then(response => {
            console.log(response);
            setColumns(response)
        }).catch(error => {
            console.log(error)
        })

        connectService.setNowWorksheetId(navigation.getParam('worksheetId'))

        /*let x = AppUser.getWorksheetsRecords()['Worksheets']

        x = x.filter(item => item.idworksheet == navigation.getParam('worksheetId')
                            && (item.rowindex == 0 || item.rowindex == 1) )
        x = [[...x.slice(0, (x.length / 2))], [...x.slice(x.length / 2)]]*/

        //setworksheetContent(x)

    }, [])

    const searchForData = () => {

        fetch(environment.prodApiUrl + "api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue)
        .then(response => response.json())
        .then(response => {
            console.log(response);
            //console.log(JSON.stringify(response))
            console.log("------");
            console.log(JSON.stringify(response[0]));
            setworksheetContent(response)
        }).catch(error => {
            console.log(error)
        })
    }

    const showRecordData = (rowIndex) => {
        console.log(rowIndex);
        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            rowIndex: rowIndex,
            workSheetRecord: worksheetContent[rowIndex],
            connectService: connectService
        })
    }

    const filterContent = (text) => {
        setfilteredValue(text)

        if(text.length < 3) return

        searchForData()
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

            <View>
                <Text style={globalStyles.chooseWorkbookHeader}> Worksheet Content (Table) </Text>
            </View>

            <View>
                <TextInput
                    value={filteredValue}
                    style={globalStyles.inputStyle}
                    onChangeText={(text) => filterContent(text)}
                    placeholder="Filter.."
                />
            </View>

            <View>

                <View style={globalStyles.tableContainer}>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[0]?.map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[1]?.map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </DataTable.Title>
                        })}

                    </DataTable.Header>

                    {
                        worksheetContent?.map( (row, rowIndex) => {
                            return(<DataTable.Row key={ rowIndex } style={worksheetContentCSS.customRow} >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    return (
                                    <DataTable.Cell
                                        key={column.id}
                                        onPress={ () => showRecordData(rowIndex) }
                                        style={worksheetContentCSS.cell}>

                                        <Text>{column.value}</Text>
                                    </DataTable.Cell>)
                                } ) }
                            </DataTable.Row>)
                        } )
                    }

                </View>

            </View>

        </View>
    )
}
