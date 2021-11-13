import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable, Image } from 'react-native'
import { ProductStyle as ps } from '../styles/ProductStyle'
import { DataTable } from 'react-native-paper'
import { modalStyles } from '../styles/modalStyles'
import AppUser from '../shared/AppUser'
import {
    getAvailableValuesForSelectedOptionUrl,
    getProductsEx,
    PostRequestParams
} from '../shared/RequestConfig'
import { imagesManager } from '../shared/ImageSelector'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { Picker } from '@react-native-community/picker'
import {
    createFilterDto,
    getAvailableTypeForWorksheet,
    typesOfSearch
} from './ProductsList_Config'
import { Product_AreaQuantityInputsStyle as aqis } from '../components/Product_AreaQuantityInputsStyle'
import { ProductsListInputsStyles as plis } from './ProductsList_Styles'

let availableValues = []

export default function ProductsList({ route, navigation }) {

    const [ProductsListHook, setProductsListHook] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)
    const [SelectedFilterTypeIndexHook, setSelectedFilterTypeIndexHook] = useState(0)
    const [SelectedFilteredIndexHook, setSelectedFilteredIndexHook] = useState(0)

    useEffect(() => {
        AppUser.setWorksheetId(navigation.getParam('worksheetId'))
        const worksheetId = navigation.getParam('worksheetId')

        const selectedTypeIndex = getAvailableTypeForWorksheet(worksheetId)
        console.log(selectedTypeIndex)
        setSelectedFilterTypeIndexHook(selectedTypeIndex)

        const x = typesOfSearch[selectedTypeIndex]

        getAvailableValuesForSelectedType(x)




        //setProductsListHook(productsList)
        //searchForData()

    }, [])



    const getAvailableValuesForSelectedType = (type_) => {
        setloading(true)
        console.log(type_)
        const x = createFilterDto(navigation.getParam('worksheetId'), type_)
        console.log(x)

        fetch(getAvailableValuesForSelectedOptionUrl, PostRequestParams(x))
        .then(response => response.json())
        .then(response => {
            console.log(response)
            availableValues = response

        }).catch(error => {
            console.log(error)
        }).finally(() => {
            setloading(false)
        })

    }

    const searchForData = () => {
        setloading(true)

        const selectedTypeOfSearch = typesOfSearch[SelectedFilterTypeIndexHook]

        const x = createFilterDto(
            navigation.getParam('worksheetId'),
            selectedTypeOfSearch,
            availableValues[SelectedFilteredIndexHook],
            skipCounter
        )

        console.log(x)

        fetch(getProductsEx, PostRequestParams(x))
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
        console.log(ProductsListHook[index_].product)
        AppUser.setWProductId(ProductsListHook[index_].product.id)

        navigation.navigate('Product', {
            productId: ProductsListHook[index_].product.id,
        })
    }

    const filterContent = () => {
        setProductsListHook(prev => {return []})
        setNomoredata(prev => {return false})
        setSkipCounter(prev => {return 0})

        searchForData(filteredValue, 0)
    }

    const setFilterText = (text_) => {
        setfilteredValue(prev => {return text_})
    }

    const reloadApp = () => {
        searchForData()
    }

    const selectType = (value_, index_) => {
        console.log(value_)
        console.log(index_)
        setSelectedFilterTypeIndexHook(index_)
        getAvailableValuesForSelectedType(value_)
        setSelectedFilteredIndexHook(0)

    }

    const selectValue = (idx_) => {
        setSelectedFilteredIndexHook(idx_)
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

            <View style={{height: 40, alignItems: 'center', justifyContent: 'center' }}>
                <Text style={{fontSize: 17, fontWeight: 'bold'}}>{ navigation.getParam('worksheetName')}</Text>
            </View>

            <View style={[plis.comboView, {flexDirection: 'row'}]}>

                <View style={{width: '30%'}}>
                    <Pressable style={[plis.filterByLabel, {height: 50}]}>
                        <Text style={plis.filterByLabelText}>Search By :</Text>
                    </Pressable>
                </View>

                <View style={{width: '70%'}}>
                    <Picker
                        selectedValue="Choose"
                        style={aqis.ComboPicker}
                        selectedValue={typesOfSearch[SelectedFilterTypeIndexHook]}
                        onValueChange={(itemValue, index) => { selectType(itemValue, index) }}>

                            { typesOfSearch.map( (item, index2) => {
                                return <Picker.Item style={aqis.CombiItem} key={index2} label={item} value={item} />
                            })}

                    </Picker>
                </View>

            </View>

            <View style={{marginTop: 5, marginLeft: 15, marginRight: 15}}>

                <Picker
                    style={aqis.ComboPicker}
                    selectedValue={availableValues[SelectedFilteredIndexHook]}
                    onValueChange={(itemValue, index) => { selectValue(index) }}>

                        { availableValues.map( (item, index2) => {
                            return <Picker.Item style={aqis.CombiItem} key={index2} label={item} value={item} />
                        })}

                </Picker>

            </View>

            <View style={plis.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={ps.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter by text or leave empty.."
                />
                <View style={ps.filterButtonView}>
                    <Pressable style={ps.filterButton} onPress={filterContent}>
                    {/* <TouchableOpacity style={ps.filterButton} onPress={filterContent}> */}
                        <Text style={ps.textUpdate}>Find</Text>
                    {/* </TouchableOpacity> */}
                    </Pressable>
                </View>

            </View>

            <ScrollView>

                <View style={globalStyles.tableContainer}>

                    {
                        ProductsListHook?.map( (product_, index) => {

                            let product = product_.product

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

                                        <TouchableOpacity onPress={ () => showProductDetails(index) }>
                                            <View onClick={ () => showProductDetails(index) } style={{ margin: 5, height: 40, justifyContent: 'center'}}>
                                                <Text style={ps.small}>{product.productaccountreference}</Text>
                                            </View>
                                        </TouchableOpacity>

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
                // <TouchableOpacity onPress={ loadMore }>
                    <View onPress={loadMore} style={ps.loadMoreView}>
                        <Text  style={ps.loadMoreText}>
                            Load more data
                        </Text>
                    </View>
                // </TouchableOpacity>
            ) }

        </ScrollView>
    )
}
