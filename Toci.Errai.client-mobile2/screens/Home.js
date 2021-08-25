import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import { FlatList, ScrollView, TouchableOpacity, TouchableWithoutFeedback } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'
import NoConnectionScreen from "./NoConnectionScreen";
import {checkConnected} from '../routes/isConnected';

export default function Home( { navigation }) {

    const [connectStatus, setConnectStatus] = useState(false);
    checkConnected().then(res=>{
        setConnectStatus(res)
    })

    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [indexer, setIndexer] = useState(3)
    const [filteredValue, setfilteredValue] = useState("")

    const pressHandler = () => {
        navigation.navigate('ReviewDetails')
    }

    useEffect( () => {
        fetch("https://localhost:44326/api/Workbook/GetAllWorkbooks")
            .then( response => response.json() )
            .then( response => {
                console.log(response)
                setworkbooks(response.result)
                setdisplayedWorkbooks(response.result)
            })
    }, [indexer] )


    const showWorksheets = (_id) => {
        navigation.navigate('ReviewDetails', {id : _id} )
    }


    const [person, setPerson] = useState( () => [
        { name: 'List1', age: 47, id: 1 },
        { name: 'List2', age: 47, id: 2 },
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

    return (
        connectStatus? (
        // <TouchableWithoutFeedback onPress={ () => { Keyboard.dismiss(); }  } >
            <View style={globalStyles.container}>
                <View style={[globalStyles.content, {backgroundColor: "orange"}]}>
                    <Button onPress={() => checkConnected()} title="Check Internet Connectivity" color="#841584"/>
                </View>
                {/* <View style={globalStyles.header}>
                    <Text onPress={pressHandler}>GO TO DETAILS</Text>
                </View> */}


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
                    { displayedWorkbooks.map( (item, index) =>
                        <View style={ globalStyles.lists } key={ index } >

                                <Text onPress={ () => showWorksheets(item.id) }>
                                    { item.name }
                                </Text>
                        </View>
                     ) }
                </View>



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
            </View>
        // </TouchableWithoutFeedback>
        ):(
            <NoConnectionScreen onCheck={checkConnected}/>
        ));
}
