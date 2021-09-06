import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput } from 'react-native'
import { worksheetContentCSS } from '../styles/worksheetContent'
import { DataTable } from 'react-native-paper'
import { environment } from '../environment'
import { modalStyles } from '../styles/modalStyles'

let tempColumns = 4

export default function WorksheetContent({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [columns, setColumns] = useState([[],[]])
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)

    useEffect(() => {
        connectService.setNowWorksheetId(navigation.getParam('worksheetId'))

        apiFetch()
    }, [])

    const apiFetch = () => {
        setloading(true)
        fetch(environment.prodApiUrl + "api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId'))
        .then(response => response.json())
        .then(response => {
            console.log(response)
            setColumns(response)
        }).catch(error => {
            console.log(error)
            setApierror(true)
        }).finally(x => {
            setloading(false)
        })
    }

    const searchForData = () => {
        setloading(true)
        let x = environment.prodApiUrl + "api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue + "/" + skipCounter
        console.log(x)
        fetch(x)
        .then(response => response.json())
        .then(response => {
            setworksheetContent(prev => {
                return [...prev, ...response]
            })

            if(response.length == 0) {
                setNomoredata(true)
            }

        }).catch(error => {
            console.log(error)
        }).finally(x => {
            setloading(false)
            setSkipCounter(prev => prev + 1)
        })
    }

    const loadMore = () => {
        if(!nomoredata) searchForData()
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
        setSkipCounter(0)
        setfilteredValue(text)

        if(text.length < 3) return

        searchForData()
    }

    if (loading) {
        return(
            <View style={modalStyles.tempContainer}>
                <Text style={modalStyles.tempText}>Wait..</Text>
            </View>
        )
    }

    if(apierror) return(
        <View>
            <View style={globalStyles.noConnectionView}>
                <Text style={globalStyles.noConnectionText}> NO CONNECTION </Text>
            </View>

            <View style={globalStyles.reloadView}>
                <Text onPress={reloadApp} style={globalStyles.reloadText}> RELOAD </Text>
            </View>

        </View>
    )

    return (
        <View style={globalStyles.content}>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

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
                                    console.log(column.id)
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

            { nomoredata && (
                <View style={worksheetContentCSS.nomoredataView}>
                    <Text style={worksheetContentCSS.nomoredataText}>No more data</Text>
                </View>
            ) }

            { !nomoredata && worksheetContent.length > 0 && (
                <View style={worksheetContentCSS.loadMoreView}>
                    <Text onPress={loadMore} style={worksheetContentCSS.loadMoreText}>
                        Load more data
                    </Text>
                </View>
            ) }

        </View>
    )
}
