import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput } from 'react-native'
import { worksheetContent as worksheetContentCSS } from '../styles/worksheetContent'
import AppUser from '../shared/AppUser'

let tempColumns = 6

export default function WorksheetContent({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columns, setColumns] = useState([[], []])
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)

    useEffect(() => {

        connectService.setNowWorksheetId(navigation.getParam('worksheetId'))

        let x = AppUser.getWorksheetsRecords()

        x = x.filter(item => item.idworksheet == navigation.getParam('worksheetId')
                            && (item.rowindex == 0 || item.rowindex == 1) )
        x = [[...x.slice(0, (x.length / 2))], [...x.slice(x.length / 2)]]

        setColumns(x)

    }, [])

    const searchForData = () => {

        fetch(environment.apiUrl + "api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue)
        .then(response => response.json())
        .then(response => {
            setworksheetContent(response)
        }).catch(error => {
            console.log(error)
        })
    }

    const showRecordData = (rowIndex) => {

        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            rowIndex: rowIndex,
            workSheetRecord: worksheetContent[rowIndex],
            connectService: connectService
        })
    }

    const filterContent = (text) => {
        setfilteredValue(text)

        if(text < 3) return

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

                    <View style={globalStyles.HalfHeader}>

                        {columns && columns[0]?.map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <View key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </View>
                            )
                        })}

                    </View>

                    <View style={globalStyles.HalfHeader}>

                        {columns && columns[1]?.map((column, index) => {
                            if(index > tempColumns) return
                            return <View key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </View>
                        })}

                    </View>

                    {
                        worksheetContent?.map( (row, rowIndex) => {
                            console.log(row)
                            return(<View key={ rowIndex } style={worksheetContentCSS.customRow} >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    return (
                                    <View
                                        key={column.id}
                                        onPress={ () => showRecordData(rowIndex) }
                                        style={worksheetContentCSS.cell}>

                                        <Text>{column.value}</Text>
                                    </View>)
                                } ) }
                            </View>)
                        } )
                    }

                </View>

            </View>

        </View>
    )
}
