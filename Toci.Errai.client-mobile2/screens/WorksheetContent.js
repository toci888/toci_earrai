import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable } from 'react-native'
import { worksheetContentCSS } from '../styles/worksheetContent'
import { DataTable } from 'react-native-paper'
import { environment } from '../environment'
import { modalStyles } from '../styles/modalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

let tempColumns = 3

export default function WorksheetContent({ route, navigation }) {

    //const [connectService] = useState( navigation.getParam('connectService') )
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [columns, setColumns] = useState([[],[]])
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)

    useEffect(() => {
        //connectService.setNowWorksheetId(1)

        let x = JSON.parse('[{"id":572,"idcategories":1,"idworksheet":1,"rowindex":null,"productaccountreference":"PL_1_2500_1250","description":"PL_1_2500_1250 @ 7.85Kg/m2","idcategoriesNavigation":null,"idworksheetNavigation":null,"areaquantities":[],"productoptionvalues":[],"productsizes":[],"quoteandprices":[]},{"id":573,"idcategories":1,"idworksheet":1,"rowindex":null,"productaccountreference":"PL_1_2500_1250","description":"PL_1_2500_1250 @ 7.85Kg/m2","idcategoriesNavigation":null,"idworksheetNavigation":null,"areaquantities":[],"productoptionvalues":[],"productsizes":[],"quoteandprices":[]}]')
        console.log(x)
        setworksheetContent(prev => {
            return x
        })
        setloading(false)
        //apiFetch()
    }, [])

    const apiFetch = () => {
        setloading(true)
        fetch(environment.apiUrl + "api/Product/GetProducts/1")// + navigation.getParam('worksheetId'))
        .then(response => response.json())
        .then(response => { setColumns(response); console.log(response); console.log(JSON.stringify(response)); })
        .catch(error => { setApierror(true) })
        .finally(() => { setloading(false) })
    }

    const searchForData = (filteredValue_, skipCounter_) => {
        setloading(true)
        let x = environment.apiUrl + "api/Product/GetProducts/1"
                    /*+ navigation.getParam('worksheetId') + "/" + filteredValue_ + "/" + skipCounter_*/
        console.log(x)
        fetch(x)
        .then(response => response.json())
        .then(response => {
            console.log(response)
            console.log(JSON.stringify(response))
            setSkipCounter(prev => prev + 1)
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
        })
    }

    const loadMore = () => {
        if(!nomoredata) searchForData(filteredValue, skipCounter)
    }

    const showProductDetails = (rowIndex) => {
        console.log(rowIndex);
        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            rowIndex: rowIndex,
            workSheetRecord: worksheetContent[rowIndex],
            //connectService: connectService
        })
    }

    const filterContent = () => {
        setworksheetContent(prev => {return []})
        setNomoredata(prev => {return false})
        setSkipCounter(prev => {return 0})

        searchForData(filteredValue, 0)
    }

    const setFilterText = (text) => {
        setfilteredValue(prev => {return text})
    }

    const reloadApp = () => {
        apiFetch()
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
        <ScrollView style={globalStyles.content}>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            <View>
                <Text style={globalStyles.chooseWorkbookHeader}> Worksheet Content (Table) </Text>
            </View>

            <View style={worksheetContentCSS.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={worksheetContentCSS.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter.."
                />
                <View style={worksheetContentCSS.filterButtonView}>
                    <Pressable style={worksheetContentCSS.filterButton} onPress={filterContent}>
                        <Text style={worksheetContentCSS.textUpdate}>Find</Text>
                    </Pressable>
                </View>

            </View>

            {/* <ScrollView> */}

                <View style={globalStyles.tableContainer}>

                    {/* <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[0]?.map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell, {flex: 3}} > <Text>{column.value}</Text> </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[1]?.map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </DataTable.Title>
                        })}

                    </DataTable.Header> */}

                    {/*
                        worksheetContent?.map( (row, rowIndex) => {
                            return(<DataTable.Row key={ rowIndex } style={worksheetContentCSS.customRow} >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    //console.log(column.id)
                                    return (
                                    <DataTable.Cell
                                        key={column.id}
                                        onPress={ () => showProductDetails(rowIndex) }
                                        style={worksheetContentCSS.cell}>

                                        <Text>{column.value}</Text>
                                    </DataTable.Cell>)
                                } ) }
                            </DataTable.Row>)
                        } )
                    */}

                    {
                        worksheetContent?.map( (product, index) => {
                            return(<DataTable.Row key={ index } style={worksheetContentCSS.customRow}>

                                <DataTable.Cell
                                    key={product.id}
                                    onPress={ () => showProductDetails(index) }
                                    style={worksheetContentCSS.cell}>

                                        <Text>{product.productaccountreference}</Text>
                                        <Text> </Text>
                                        <Text>{product.description}</Text>

                                </DataTable.Cell>

                            </DataTable.Row>)
                        } )
                    }

                </View>

            {/* </ScrollView> */}

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

        </ScrollView>
    )
}
