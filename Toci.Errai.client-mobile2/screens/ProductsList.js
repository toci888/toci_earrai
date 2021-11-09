import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable, Image } from 'react-native'
import { ProductStyle as ps } from '../styles/ProductStyle'
import { DataTable } from 'react-native-paper'
import { modalStyles } from '../styles/modalStyles'
import AppUser from '../shared/AppUser'
import { getProductsEx, PostRequestParams } from '../shared/RequestConfig'
import { imagesManager } from '../shared/ImageSelector'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { FilterRequestConfig } from '../shared/FilterRequestConfig'

export default function ProductsList({ route, navigation }) {

    const [ProductsListHook, setProductsListHook] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)

    useEffect(() => {
        AppUser.setWorksheetId(navigation.getParam('worksheetId'))
        //setProductsListHook(productsList)
        searchForData()

    }, [])

    const searchForData = (phrase_= "empty", skip_ = 0) => {
        setloading(true)

        fetch(getProductsEx, PostRequestParams(FilterRequestConfig(1, 2, skip_)))
        .then(response => response.json())
        .then(response => {
            console.log(response)
            /*setSkipCounter(prev => prev + 1)
            setProductsListHook(prev => {
                return [...prev, ...response]
            })

            if(response.length == 0) {
                setNomoredata(true)
            }*/

        }).catch(error => {
            console.log(error)
            console.log("NIET")
        }).finally(() => {
            setloading(false)
        })
    }

    const loadMore = () => {
        const toFilter = (filteredValue == "") ? "empty" : filteredValue
        if(!nomoredata) searchForData(toFilter, skipCounter)
    }

    const showProductDetails = (index_) => {

        AppUser.setWProductId(ProductsListHook[index_].id)

        navigation.navigate('Product', {
            productId: ProductsListHook[index_].id,
        })
    }

    const filterContent = () => {
        setProductsListHook(prev => {return []})
        setNomoredata(prev => {return false})
        setSkipCounter(prev => {return 0})

        searchForData(filteredValue, 0)
    }

    const setFilterText = (text) => {
        setfilteredValue(prev => {return text})
    }

    const reloadApp = () => {
        searchForData()
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

            <View style={ps.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={ps.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter.."
                />
                <View style={ps.filterButtonView}>
                    <Pressable style={ps.filterButton} onPress={filterContent}>
                        <Text style={ps.textUpdate}>Find</Text>
                    </Pressable>
                </View>

            </View>

            <ScrollView>

                <View style={globalStyles.tableContainer}>

                    {
                        ProductsListHook?.map( (product, index) => {

                            let img = imagesManager[product.idcategories]?.url

                            return(<DataTable.Row key={ index } style={ps.customRow}>

                                <View key={product.id} style={[ps.cell, {height: 50, marginTop: 25, width: '100%'}]}>

                                    <View style={{display: 'flex', flexDirection: 'row'}}>

                                        <TouchableOpacity onPress={ () => showProductDetails(index) }>
                                            { img &&

                                                <View style={{ height: 40, width: 30, margin: 5}}>
                                                    <Image
                                                        style={{height: 40, width:'100%', justifyContent:'center', marginRight: 5}}
                                                        source={img}
                                                    />
                                                </View>
                                            }
                                        </TouchableOpacity>

                                        <View onClick={ () => showProductDetails(index) } style={{ margin: 5, height: 40, justifyContent: 'center'}}>
                                            <Text style={ps.small}>{product.productaccountreference}</Text>
                                        </View>

                                        <View style={{ height: 40, padding: 5, margin: 5, justifyContent: 'center'}} >
                                            <Text style={ps.small}>{product.description}</Text>
                                        </View>

                                    </View>

                                </View>

                            </DataTable.Row>)
                        } )
                    }

                </View>

            </ScrollView>

            { nomoredata && (
                <View style={ps.nomoredataView}>
                    <Text style={ps.nomoredataText}>No more data</Text>
                </View>
            ) }

            { !nomoredata && ProductsListHook.length > 0 && (
                <View style={ps.loadMoreView}>
                    <Text onPress={loadMore} style={ps.loadMoreText}>
                        Load more data
                    </Text>
                </View>
            ) }

        </ScrollView>
    )
}
