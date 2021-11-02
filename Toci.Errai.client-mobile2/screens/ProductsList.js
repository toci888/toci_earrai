import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable } from 'react-native'
import { ProductStyle } from '../styles/ProductStyle'
import { DataTable } from 'react-native-paper'
import { modalStyles } from '../styles/modalStyles'
import { productCSS } from '../styles/Product_Util_Styles'
import AppUser from '../shared/AppUser'
import { getProductsFromWorksheet } from '../shared/RequestConfig'

export default function ProductsList({ route, navigation }) {

    const [ProductsListHook, setProductsListHook] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)

    useEffect(() => {
        AppUser.setWorksheetId(navigation.getParam('worksheetId'))
        searchForData()
    }, [])

    const searchForData = (phrase_= "empty", skip_ = 0) => {
        setloading(true)

        fetch(getProductsFromWorksheet(AppUser.getWorksheetId(), phrase_, skip_))
        .then(response => response.json())
        .then(response => {
            console.log(response)
            setSkipCounter(prev => prev + 1)
            setProductsListHook(prev => {
                return [...prev, ...response]
            })

            if(response.length == 0) {
                setNomoredata(true)
            }

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

            <View style={productCSS.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={productCSS.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter.."
                />
                <View style={productCSS.filterButtonView}>
                    <Pressable style={productCSS.filterButton} onPress={filterContent}>
                        <Text style={productCSS.textUpdate}>Find</Text>
                    </Pressable>
                </View>

            </View>

            <ScrollView>

                <View style={globalStyles.tableContainer}>


                    {
                        ProductsListHook?.map( (product, index) => {
                            return(<DataTable.Row key={ index } style={productCSS.customRow}>

                                <DataTable.Cell
                                    key={product.id}
                                    onPress={ () => showProductDetails(index) }
                                    style={productCSS.cell}>

                                        <Text style={productCSS.small}>{product.productaccountreference}</Text>
                                        <Text>, </Text>
                                        <Text style={productCSS.small}>{product.description}</Text>

                                </DataTable.Cell>

                            </DataTable.Row>)
                        } )
                    }

                </View>

            </ScrollView>

            { nomoredata && (
                <View style={productCSS.nomoredataView}>
                    <Text style={productCSS.nomoredataText}>No more data</Text>
                </View>
            ) }

            { !nomoredata && ProductsListHook.length > 0 && (
                <View style={productCSS.loadMoreView}>
                    <Text onPress={loadMore} style={productCSS.loadMoreText}>
                        Load more data
                    </Text>
                </View>
            ) }

        </ScrollView>
    )
}
