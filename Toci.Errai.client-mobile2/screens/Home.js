import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import { FlatList, ScrollView, TouchableOpacity, TouchableWithoutFeedback } from 'react-native-gesture-handler'
import { globalStyles, tabStyle } from '../styles/globalStyles'
import NoConnectionScreen from "./NoConnectionScreen";
//import { checkConnected } from '../routes/isConnected';
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import { DataTable } from 'react-native-paper';

let columns = ["workbookId", "workSheetName", "row", "column", "value", "EDIT"]

export default function Home( { navigation }) {

    // checkConnected().then(res=> {
    //     setConnectStatus(res)
    // })

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [connectStatus, setConnectStatus] = useState(false)
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [indexer, setIndexer] = useState(3)
    const [filteredValue, setfilteredValue] = useState("")

    const pressHandler = () => {
        navigation.navigate('ReviewDetails')
    }

    useEffect( () => {
        console.log("USE_EFFECT_START");
        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 6000)

        return () => clearInterval(interval)

        /*fetch("https://localhost:44326/api/Workbook/GetAllWorkbooks")
            .then( response => response.json() )
            .then( response => {
                console.log(response)
                setworkbooks(response.result)
                setdisplayedWorkbooks(response.result)
            })*/
    }, [] )

    const showWorksheets = (_id) => {
        navigation.navigate('ReviewDetails', {id : _id} )
    }


    const [person, setPerson] = useState( () => [
        { name: 'List1', age: 47, id: 1 },
        { name: 'List2', age: 47, id: 2 },
    ])



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

    const clickHandler = () => {
        console.log( JSON.stringify(workbooks) );
        setPerson( prevState => [...prevState, {name: 'Arturo', age: 44, id: indexer}])
        setIndexer(prev => prev + 1)
    }

    const testAlert = () => {
        Alert.alert("UUUUUUUUPS", "Za malo kodzenia", [{ text: 'Kapuje', onPress: ()  => console.log("11") }] )
    }


    const filterWorkbooks = (e) => {
        console.log(e.target.value);
        setfilteredValue(e.target.value)

        let filtered = workbooks.filter(item => item.name.toLowerCase().includes( e.target.value.toLowerCase() ))

        setdisplayedWorkbooks(filtered)


    }

    const renderRow = () => {
        return  (
            <View style={{ flex: 1, alignSelf: 'stretch', flexDirection: 'row' }}>
                <View style={{ flex: 1, alignSelf: 'stretch' }} />
                <View style={{ flex: 1, alignSelf: 'stretch' }} />
                <View style={{ flex: 1, alignSelf: 'stretch' }} />
                <View style={{ flex: 1, alignSelf: 'stretch' }} />
                <View style={{ flex: 1, alignSelf: 'stretch' }} />
            </View>
        )

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const changeValue = (index) => {
        console.log("Zmieniamy wartość");
        console.log(dbData)
        let tempDbdata = [...dbData]
        let x = {...dbData[index]}


        console.log(x)
        console.log(connectService.cacheData);
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(x)
        }

        x.value = "ZMIENIONA_WARTOSC"

        tempDbdata[index] = x
        setdbData(tempDbdata)
    }

    return (
        connectService.isConnectedFunc() ? (
        // <TouchableWithoutFeedback onPress={ () => { Keyboard.dismiss(); }  } >
            <View style={globalStyles.container}>

                {/* <View style={[globalStyles.content, {backgroundColor: "orange"}]}>
                    <Button onPress={() => checkConnected()} title="Check Internet Connectivity" color="#841584"/>
                </View> */}

                <View style={globalStyles.header}>
                    <Text onPress={disconnect}> !!! DISCONNECT !!!</Text>
                </View>

                <View style={ globalStyles.content } >
                    <Text style={ globalStyles.chooseWorkbookHeader }> All Workbooks </Text>
                    <View>
                        <TextInput
                            value={ filteredValue }
                            style={ globalStyles.inputStyle }
                            placeholder="Filter.."
                            onChange={ ($event) => filterWorkbooks($event) }
                        />
                    </View>

                    {/* <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
                        {
                            data.map((datum) => { // This will render a row for each data element.
                                return this.renderRow();
                            })
                        }
                    </View> */}



                    <View style={ globalStyles.lists } style={{flexDirection:'row'}}>

                        { displayedWorkbooks.map( (item, index) =>

                            <Text key={ index } onPress={ () => showWorksheets(item.id) }>
                                { item.name }
                            </Text>

                        ) }

                    </View>

                </View>


                <View style={globalStyles.fakeTable}>
                    <Text> FAKE TABLE </Text>
                </View>

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


                {/* <View>
                    <Text style={{display: 'inline'}}>
                        { columns.map( (value, index) => <Text style={{width: '20%'}} key={ index }> {value} </Text> ) }
                    </Text>
                </View>

                <View>
                    { dbData.map( (value, index) => {
                        return (
                            <Text key={ index }>
                            <Text> {value.workbookId} </Text>
                            <Text> {value.workSheetName} </Text>
                            <Text> {value.column} </Text>
                            <Text> {value.row} </Text>
                            <Text> {value.value} </Text>
                            <Text>
                                <Button title={"Change value"} onPress={ () => changeValue(index) } />
                            </Text>
                            </Text>

                        )
                    } ) }
                </View> */}



                {/* .toString() keyExtractor ? */}
                {/* <FlatList
                    keyExtractor={ (item) => item.id.toString() }
                    data={workbooks}
                    renderItem={ ( { item } ) => (
                        <TouchableOpacity onClick={ () => editList(1) } onPress={ () => navigation.navigate('ReviewDetails', item )}>

                            <Text> { item.name } </Text>

                        </TouchableOpacity>

                    )}
                /> */}

                {/* <FlatList
                    keyExtractor={ (item) => item.id.toString() }
                    data={person}
                    renderItem={ ( { item } ) => (

                            <View onPress={ () => navigation.navigate('ReviewDetails', item )}>

                                <Text style={globalStyles.item}>
                                    <Text style={globalStyles.item}> { item.name } </Text>
                                    <Text style={globalStyles.item}> <Button onPress={editList(item.id)} title="Edit" /></Text>
                                </Text>

                            </View>


                    )}
                /> */}

                <StatusBar style="auto" />
                {/* <CacheModuleService></CacheModuleService> */}
            </View>

        // </TouchableWithoutFeedback>
        ) : (
            <View><Text>NO CONNECTION</Text></View>
            //  <NoConnectionScreen onCheck={checkConnected} />
        ))
}
