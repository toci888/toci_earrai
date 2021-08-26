import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'

export default function WorksheetContent( { route, navigation} ) {

    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect( () => {
        fetch("https://localhost:44326/api/Workbook/GetAllWorksheets/" + navigation.getParam('id'))
            .then( response => response.json() )
            .then( response => {
                console.log(response)
                setworksheets(response.result)
                setdisplayedWorksheets(response.result)
                setloading(false)
            })
    }, [] )

    const pressHandler = () => {
        console.log(1)
    }

    const [dbData, setdbData] = useState( () => [
        {
            workbookId: 6,
            workSheetName: "Arkusz3",
            row: 10,
            column: 5,
            value: "DUPA6"
        },
        {
            workbookId: 2,
            workSheetName: "Arkusz7",
            row: 13,
            column: 31,
            value: "DUPA12"
        },
    ])

    const filterWorkbooks = (e) => {

        console.log(e.target.value);
        setfilteredValue(e.target.value)

        let filtered = worksheets.filter(item => item.name.toLowerCase().includes( e.target.value.toLowerCase() ))

        setdisplayedWorksheets(filtered)

    }

    if(loading) {
        return(

            <View style={ globalStyles.loading }>

                <Text style={ globalStyles.loadingText }>Loading..</Text>

            </View>
        )
    }

    return (

        <View style={ globalStyles.content }>

            <Text style={globalStyles.chooseWorkbookHeader}> All Worksheets </Text>

            <View>

                <TextInput
                    value={filteredValue}
                    style={globalStyles.inputStyle}
                    onChange={ ($event) => filterWorkbooks($event) }
                    placeholder="Filter.."
                />

            </View>

            { displayedWorksheets.map( (item, index) =>
                <View style={ globalStyles.lists } key={ index } >

                        <Text onPress={ () => showWorksheets(item.id) }>
                            { item.name }
                        </Text>

                </View>
            ) }

            {/* <View  >

                { worksheets.map( (item, index) => {
                    return <Button style={ globalStyles.item } key={ index }
                                title={ item.name } onPress={ pressHandler }
                            />
                }) }
            </View> */}

            <View>

                <DataTable>

                    <DataTable.Header>
                        {
                            columns.map( (value, index) => {
                                return <DataTable.Title key={ index }> {value} </DataTable.Title>
                            } )
                        }
                    </DataTable.Header>

                    {
                        dbData.map( (value, index) => {
                            return(
                                <DataTable.Row key={ index }>
                                    <DataTable.Cell style={tabStyle.cell} > {value.workbookId} </DataTable.Cell>
                                    <DataTable.Cell style={tabStyle.cell}> {value.workSheetName} </DataTable.Cell>
                                    <DataTable.Cell style={tabStyle.cell}> {value.column} </DataTable.Cell>
                                    <DataTable.Cell style={tabStyle.cell}> {value.row} </DataTable.Cell>
                                    <DataTable.Cell style={tabStyle.cell}> {value.value} </DataTable.Cell>
                                    <DataTable.Cell style={tabStyle.cell}>
                                        <Button title={"Change value"} onPress={ () => changeValue(index) } />
                                    </DataTable.Cell>
                                </DataTable.Row>
                            )
                        } )
                    }

                </DataTable>

            </View>

        </View>
    )
}
