import React, { useEffect, useState } from 'react'
import { Alert, Text, View, ScrollView, Image } from 'react-native'
import AppUser from '../../shared/AppUser'
import { modalStyles } from '../../styles/modalStyles'
import ProductPrices from './ProducPrices'
import ProductSizes from './productSizes'
import { getAreasQuantitiesByProduct, getProductUrl } from '../../shared/RequestConfig'
import ProductDetails from './ProductDetails'
import Product_AreaQuantityButtons from '../../components/Product_AreaQuantityButtons'
import Product_AreaQuantityInputs from '../../components/Product_AreaQuantityInputs'
import Product_UtilTable from '../../components/Product_UtilTable'
import { productCSS } from '../../styles/Product_Util_Styles'
import Product_AreaQuantities from '../../components/Product_AreaQuantities'
import Vendors from '../../components/Vendors/Vendors'
import { imagesManager } from '../../shared/ImageSelector'
import  Product_Commisions  from './../../components/Product_Commisions'

export default function Product({ route, navigation }) {

    const [ProductHook, setProduct] = useState([])
    const [SnackHook, setSnack] = useState({
        type: null,
        message: "",
    })

    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [UpdatingIndex, setUpdatingIndex] = useState(null)
    const [loading, setloading] = useState(true)
    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 1,
        idproducts: AppUser.getProductId(),
        idcodesdimensions: 1,
        iduser: AppUser.getId(),
        quantity: "",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    useEffect( () => {

        /*fetch('http://localhost:18158/api/QuoteAndPrice/GetAllVendorsFromDb')
        .then(r => r.json())
        .then(r => { console.log(r); console.log('OK') })
        .catch(r => { console.log(r)})*/
        fetchAreas()

        /*const response_ = productData
        console.log(response_)

        setProduct(response_)

        settempAreaquantityRow(prev => {
            return {  ...prev, idproducts: response_.product.id,  }
        })

        initAreaQuantities(response_)

        setloading(false)*/
        console.log(navigation.getParam('productId'))

        fetch(getProductUrl(navigation.getParam('productId'))).then(response_ => {
            return response_.json()
        }).then(response_ => { console.log(response_)
            setProduct(response_)

            settempAreaquantityRow(prev => {
                return {  ...prev, idproducts: response_.product.id,  }
            })

            initAreaQuantities(response_)

        }).finally(x => {
            setloading(false)
        })

    }, [] )

    const initAreaQuantities = (response_) => {
        if(!response_) response_ = ProductHook

        const tempLenWid = {length: "", width: ""}
        response_.sizes.forEach(item => {
            if(item.name == "Length") tempLenWid.length = item.value
            if(item.name == "Width") tempLenWid.width = item.value
        })

        settempAreaquantityRow(prev => {
            return {
                ...prev,
                length: tempLenWid.length.toString(),
                width: tempLenWid.width.toString(),
                idarea: AppUser.getIdArea(),
                quantity: "",
            }
        })

        setbtnvalueHook("ADD")
    }

    const fetchAreas = () => {
        let x = AppUser.getAreas()
        console.log(x)
        setareas(x)

        const savedArea = AppUser.getIdArea()
        if(savedArea) {
            settempAreaquantityRow(prev => {
                return {...prev, idarea: savedArea}
            })
        }
    }

    const deleteProduct = (index_) => {
        const newProduct = ProductHook

        newProduct.areaQuantities.splice(index_, 1)
        setProduct(newProduct)
    }

    const updateAreaQuantitiesfterRequest = async () => {
        let logName, message

       fetch(getAreasQuantitiesByProduct(AppUser.getProductId())).then(response_ => {
            return response_.json()
        }).then(response_ => {
            console.log(response_)
            let newProduct = ProductHook
            newProduct.areaQuantities = response_
            setProduct(prev => {return newProduct})
            logName = "Ok"; message = "Added new(or updated) area Quantities"
        }).catch(error => {
            console.log(error);
            logName = "Error"; message = "Something went wrong"
        }).finally(x => {
            setloading(false)
            Alert.alert(
                logName,
                message,
                [ { onPress: () => console.log("OK") } ]
            )
        })
    }


    const clearInputs = () => {
        settempAreaquantityRow(prev => {
            return {...prev,
                id: 0,
                idarea: AppUser.getIdArea() || 0,
                iduser: 3,
                quantity: "",
                length: "",
                width: "",
                createdat: null,
                updatedat: null,
            }
        })
        setbtnvalueHook("ADD")
    }

    return (
        <ScrollView style={productCSS.container}>

            { imagesManager[ProductHook?.product?.idcategories]?.url &&

                <View style={{height: 100, width: '100%', justifyContent: 'center', margin: 15}}>

                    <View style={{height: 100, width: 100, margin: 10}}>
                        <Image
                            style={{height: '100%', width: '100%'}}
                            source={imagesManager[ProductHook?.product?.idcategories].url}
                        />
                    </View>
                </View>
            }

            { !imagesManager[ProductHook?.product?.idcategories]?.url &&
                <Text style={{textAlign: 'center'}} >No Image</Text>
            }

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            <ProductDetails product={ProductHook?.product} />

            <Product_AreaQuantityButtons
                tempAreaquantityRow={tempAreaquantityRow}
                btnvalueHook={btnvalueHook}
                Product={ProductHook}
                initAreaQuantities={initAreaQuantities}
                setbtnvalueHook={setbtnvalueHook}
                updateAreaQuantitiesfterRequest={updateAreaQuantitiesfterRequest}
                initAreaQuantities={initAreaQuantities}
                setloading={setloading}
            />

                <Product_AreaQuantityInputs
                    settempAreaquantityRow={settempAreaquantityRow}
                    tempAreaquantityRow={tempAreaquantityRow}
                    areas={areas}
                    setbtnvalueHook={setbtnvalueHook}
                />

            <Product_AreaQuantities
                settempAreaquantityRow={settempAreaquantityRow}
                setUpdatingIndex={setUpdatingIndex}
                areaQuantities={ProductHook.areaQuantities}
                updateAreaQuantitiesfterRequest={setProduct}
                setAreaQuantities={setProduct}
                areas={areas}
                setbtnvalueHook={setbtnvalueHook}
                setloading={setloading}
                deleteProduct={deleteProduct}
            />

            <ProductPrices product={ProductHook} />

            <Vendors />

            <ProductSizes product={ProductHook} />

            <Product_UtilTable details={ProductHook?.pricing} name="Calculations" />

            {
                ProductHook.product &&
                    <Product_Commisions productId={ProductHook.product?.id}  price={ProductHook.prices?.find(v => v.name == "PoundsPerTonne")?.price} />
            }

        </ScrollView>
    )
}
