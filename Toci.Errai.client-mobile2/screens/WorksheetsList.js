import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'

export default function WorksheetsList( { route, navigation} ) {

    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect( () => {
        fetch("https://localhost:44326/api/Workbook/GetAllWorksheetsFromDb/" + navigation.getParam('fileId'))
            .then( response => response.json() )
            .then( response => {
                console.log(response)
                setworksheets(response)
                setdisplayedWorksheets(response)
                setloading(false)
            })
    }, [] )

    const filterWorkbooks = (e) => {

        console.log(e.target.value);
        setfilteredValue(e.target.value)

        let filtered = worksheets.filter(item => item.sheetname.toLowerCase().includes( e.target.value.toLowerCase() ))

        setdisplayedWorksheets(filtered)

    }

    const showWorksheets = (id) => {
        console.log(id)
        fetch("https://localhost:44326/api/WorksheetContent/searchWorksheet/"
                + id + "/" + "Alumin")

            .then( response => response.json() )
            .then( response => {
                console.log(response)
            })
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
                <View style={ worksheetsList.listItem } key={ index } >

                    <Text onPress={ () => showWorksheets(item.id) }>
                        { item.sheetname }
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

        </View>
    )
}
