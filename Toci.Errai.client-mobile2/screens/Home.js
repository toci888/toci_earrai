import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import { FlatList, ScrollView, TouchableOpacity, TouchableWithoutFeedback } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'


export default function Home( { navigation }) {

    const pressHandler = () => {
        navigation.navigate('ReviewDetails')
    }

    const [posts, setposts] = useState([])
    const [indexer, setIndexer] = useState(3)

    useEffect( () => {
        fetch("https://jsonplaceholder.typicode.com/users")
            .then( (data)=> { let x = data.json(); setposts(data); console.log(data.reslut) })
    }, [indexer] )


    const fetchData = () => {

    }


    const [person, setPerson] = useState( () => [
        { name: 'List1', age: 47, id: 1 },
        { name: 'List2', age: 47, id: 2 },
    ])

    const clickHandler = () => {
        console.log( JSON.stringify(posts) );
        setPerson( prevState => [...prevState, {name: 'Arturo', age: 44, id: indexer}])
        setIndexer(prev => prev + 1)
    }

    const testAlert = () => {
        Alert.alert("UUUUUUUUPS", "Za malo kodzenia", [{ text: 'Kapuje', onPress: ()  => console.log("11") }] )
    }

    const editList = (id) => {
        console.log(id)
    }

    return (
            // <TouchableWithoutFeedback onPress={ () => { Keyboard.dismiss(); }  } >
                <View style={globalStyles.container}>
                    <View style={globalStyles.header}  >
                        <Text onPress={pressHandler}>GO TO DETAILS</Text>
                    </View>


                    <View style={globalStyles.header}>
                        <Text onPress={clickHandler}>ŁILO  kliknij</Text>
                    </View>
                    <View>
                        <TextInput style={globalStyles.inputStyle} />
                    </View>
                    <View>
                        <Button title='Dont click' onPress={clickHandler} />
                    </View>
                        {/* .toString() keyExtractor ? */}
                        {/* <FlatList
                            keyExtractor={ (item) => item.id.toString() }
                            data={posts}
                            renderItem={ ( { item } ) => (
                                <TouchableOpacity onPress={ () => navigation.navigate('ReviewDetails', item )}>

                                    <Text > { item.name } </Text>

                                </TouchableOpacity>

                            )}
                        /> */}

                        <FlatList
                            keyExtractor={ (item) => item.id.toString() }
                            data={person}
                            renderItem={ ( { item } ) => (
                                <TouchableOpacity onPress={ () => navigation.navigate('ReviewDetails', item )}>

                                    <View>

                                        <Text style={globalStyles.item}>
                                            <Text style={globalStyles.item}> { item.name } </Text>
                                            <Text style={globalStyles.item}> <Button onPress={editList(item.id)} title="Edit" /></Text>
                                        </Text>

                                    </View>

                                </TouchableOpacity>

                            )}
                        />



                        {/* <View style={styles.content}>
                            <Text>Hello Apka {person[0].age}</Text>
                            {person.map( (item, index) => {
                                return <Text  style={styles.item} key={index}> {item.name}, wiek: {item.age}  </Text>
                            })}
                        </View> */}
                    <View>

                        {/* {posts.map( item => (<Text key={item.id}> {item.name}</Text>) )} */}
                    </View>



                    <StatusBar style="auto" />
                </View>
            // </TouchableWithoutFeedback>
    );
}
