import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable, Image } from 'react-native'
import { ProductStyle as ps } from '../styles/ProductStyle'
import { DataTable } from 'react-native-paper'

import AppUser from '../shared/AppUser'
import {
    getAllProductsByWorksheet,
    getAvailableValuesForSelectedOptionUrl,
    getProductsEx
} from '../shared/RequestConfig'
import { imagesForWorksheet, imagesManager } from '../shared/ImageSelector'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { Picker } from '@react-native-community/picker'
import {
    createFilterDto,
    getAvailableTypeForWorksheet,
    getTypesOfSearchForWorksheet,
    typesOfSearch
} from './ProductsList_Config'
import { Product_AreaQuantityInputsStyle as aqis } from '../components/Product_AreaQuantityInputsStyle'
import { ProductsListInputsStyles as plis } from './ProductsList_Styles'
import RestClient from '../shared/RestClient';
import Waiter from '../shared/Waiter'
import checkConnected from '../shared/isConnected';
import OfflineDataProvider from '../CacheModule/OfflineDataProvider';

let availableValues = []

let filteredValues = []

function dbNameReplacer(value_) {
    if(value_.name == "DimA") value_.name = "SizeA"
    if(value_.name == "DimB") value_.name = "SizeB"
    if(value_.name == "OD") value_.name = "ChsOd"
    return value_
}

export default function ProductsList({ route, navigation }) {

    const [ProductsListHook, setProductsListHook] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [apierror, setApierror] = useState(false)
    //const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)
    const [SelectedFilterTypeIndexHook, setSelectedFilterTypeIndexHook] = useState(0)
    const [SelectedFilteredIndexHook, setSelectedFilteredIndexHook] = useState(0)
    const [availableTypesOfSearch, setAvailableTypesOfSearch] = useState([])

    let restClient = new RestClient();
    let waiter = Waiter(true);

    useEffect(() => {

        AppUser.setWorksheetId(navigation.getParam('worksheetId'))
        const worksheetId = navigation.getParam('worksheetId')

        const a = getTypesOfSearchForWorksheet(navigation.getParam('worksheetId'))
        setAvailableTypesOfSearch(a)

        const x2 = getAvailableTypeForWorksheet(worksheetId)

        const selectedTypeIndex = x2[0]

        setSelectedFilterTypeIndexHook(0)

        getAvailableValuesForSelectedType(a[0])

    }, [])



    const getAvailableValuesForSelectedType = (type_) => {
        setloading(true)
        console.log(type_)
        const x = createFilterDto(navigation.getParam('worksheetId'), type_)
        const y = dbNameReplacer(x)

        console.log("k")
        console.log(x)
        console.log(y)
        console.log(getAvailableValuesForSelectedOptionUrl)

        restClient.POST(getAvailableValuesForSelectedOptionUrl, y).then(x => {
            console.log(x);
            availableValues = x;
            filteredValues = x;
        }).catch(error => {
            console.log(error)
        }).finally(() => {
            setloading(false)
        })
    }

    const searchForData = () => {
        setloading(true)

        const selectedTypeOfSearch = availableTypesOfSearch[SelectedFilterTypeIndexHook]

        const x = createFilterDto(
            navigation.getParam('worksheetId'),
            selectedTypeOfSearch,
            filteredValues[SelectedFilteredIndexHook],
        )
        console.log(x)
        
        restClient.POST(getProductsEx, dbNameReplacer(x)).then(response => {
            if(response.length == 0) {
                setNomoredata(true);
                return;
            };

            setProductsListHook(prev => {
                return [...prev, ...response]
            });
        }).catch(error => {
            console.log(error)
        }).finally(() => {
            setloading(false)
        });
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

        searchForData(filteredValue, 0)
    }

    const setFilterText = (text_) => {

        filteredValues = availableValues.filter( (v, k) => {

            let x = v.includes(text_)
            return x

        })
        console.log(filteredValues)
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
    
    const loadAllData = async () => {
        setloading(true)
        if (checkConnected())
        {
            restClient.GET(getAllProductsByWorksheet(navigation.getParam('worksheetId'))).then(response => setProductsListHook(response))
            .catch(error => {
                console.log(error)
            }).finally(() => {
                setloading(false)
            });
        }
        else
        {
            setProductsListHook(OfflineDataProvider.getProductsByWorksheetId(navigation.getParam('worksheetId')));
            setloading(false)
        }
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
{ loading && waiter }
          
            <View style={{height: 60, flexDirection: 'row', alignItems: 'center', justifyContent: 'center' }}>
                <Text style={{fontSize: 17, fontWeight: 'bold'}}>{ navigation.getParam('worksheetName')}</Text>

                {
                    imagesForWorksheet[navigation.getParam('worksheetId')].map((v,k) => {

                        const x = imagesManager[v]?.url

                        if(!x) return

                        return(
                            <View style={{flexDirection: 'row', margin: 15}} key={k}>
                                <View style={{width: 50}}>

                                    <Image
                                        style={{height: 50, width: 50}}
                                        source={x}
                                    />

                                </View>
                            </View>
                        )
                    })
                }

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
                        selectedValue={availableTypesOfSearch[SelectedFilterTypeIndexHook]}
                        onValueChange={(itemValue, index) => { selectType(itemValue, index) }}>

                            { availableTypesOfSearch.map( (item, index2) => {

                                    return <Picker.Item style={aqis.CombiItem} key={index2} label={item} value={item} />

                            })}

                    </Picker>
                </View>

            </View>

            <View style={{marginTop: 5, marginLeft: 15, marginRight: 15, flexDirection: 'row'}}>

                <View style={{width: '30%'}}>
                    <Pressable style={[plis.filterByLabel, {height: 50}]}>
                        <Text style={plis.filterByLabelText}>Values({filteredValues.length}) : </Text>
                    </Pressable>
                </View>

                <View style={{width: '70%'}}>
                    <Picker
                        style={aqis.ComboPicker}
                        selectedValue={filteredValues[SelectedFilteredIndexHook]}
                        onValueChange={(itemValue, index) => { selectValue(index) }}>

                            { filteredValues.map( (item, index2) => {
                                return <Picker.Item style={aqis.CombiItem} key={index2} label={item} value={item} />
                            })}

                    </Picker>
                </View>

            </View>

            <View style={plis.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={ps.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter available values.."
                />
                <View style={ps.filterButtonView}>
                    <Pressable style={ps.filterButton} onPress={filterContent}>
                    {/* <TouchableOpacity style={ps.filterButton} onPress={filterContent}> */}
                        <Text style={ps.textUpdate}>Find</Text>
                    {/* </TouchableOpacity> */}
                    </Pressable>
                </View>

            </View>

            <View style={plis.filterContent}>

                <Pressable style={[ps.filterButton, {width: '100%'}]} onPress={loadAllData}>
                    {/* <TouchableOpacity style={ps.filterButton} onPress={filterContent}> */}
                        <Text style={[ps.textUpdate, {width: '100%', textAlign: 'center'}]}>Load All Products</Text>
                    {/* </TouchableOpacity> */}
                </Pressable>

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
                                                <Text style={ps.small}>{product.description}</Text>
                                                <Text style={ps.small}>{product.productaccountreference}</Text>
                                            </View>
                                        </TouchableOpacity>

                                        {/* <View style={{ height: 40, padding: 5, margin: 5, justifyContent: 'center'}} >
                                            <Text style={ps.small}>{product.description}</Text>
                                        </View> */}

                                        <View style={{ height: 40, padding: 5, margin: 5, justifyContent: 'center'}}>
                                        <Text style={ps.small}>B: {product_.balance}</Text>
                                        </View>

                                    </View>

                                </View>

                            </DataTable.Row>)
                        } )
                    }

                </View>

            </ScrollView>

            {/* { nomoredata && (
                <View style={ps.nomoredataView}>
                    <Text style={ps.nomoredataText}>No more data</Text>
                </View>
            ) } */}

            {/* { !nomoredata && ProductsListHook.length > 0 && (
                // <TouchableOpacity onPress={ loadMore }>
                    <View onClick={loadMore} style={ps.loadMoreView}>
                        <Text  style={ps.loadMoreText}>
                            Load more data
                        </Text>
                    </View>
                // </TouchableOpacity>
            ) } */}

        </ScrollView>
    )
}
