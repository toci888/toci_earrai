import React, { useEffect, useState } from 'react'
import { Text, View, ScrollView } from 'react-native'
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
import Product_Commisions from '../../components/Product_Commisions'

export default function Product({ route, navigation }) {

    const [ProductHook, setProduct] = useState([])
    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [UpdatingIndex, setUpdatingIndex] = useState(null)
    const [loading, setloading] = useState(true)
    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 1,
        idproducts: AppUser.getWProductId(),
        idcodesdimensions: 1,
        iduser: AppUser.getId(),
        quantity: "1",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    useEffect( () => {
        fetchAreas()

        fetch(getProductUrl(navigation.getParam('productId'))).then(response_ => {
            return response_.json()
        }).then(response_ => { console.log(response_)
            setProduct(response_)

            settempAreaquantityRow(prev => {
                return {  ...prev, idproducts: response_.product.id,  }
            })

            initAreaQuantities(response_)

            setloading(false)
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
            }
        })

        setbtnvalueHook("ADD")
    }

    const fetchAreas = () => {
        setareas(AppUser.getAreas())

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
       fetch(getAreasQuantitiesByProduct(AppUser.getWProductId())).then(response_ => {
            return response_.json()
        }).then(response_ => {
            console.log(response_)
            let newProduct = ProductHook
            newProduct.areaQuantities = response_
            setProduct(prev => {return newProduct})
            WorksheetRecord()
        }).catch(error => {
            console.log(error);
        }).finally(x => {
            setloading(false)
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

            <ProductSizes product={ProductHook} />

            <Product_UtilTable details={ProductHook?.pricing} name="Calculations" />

            {
                ProductHook.product &&
                    <Product_Commisions productId={ProductHook.product?.id}  price={ProductHook.prices?.find(v => v.name == "PoundsPerTonne").price} />
            }

        </ScrollView>
    )
}
