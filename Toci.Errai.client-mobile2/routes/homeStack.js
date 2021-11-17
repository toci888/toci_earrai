import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import ProductsList from '../screens/ProductsList'
import WorksheetsList from '../screens/WorksheetsList'
import Product from '../screens/Product/Product'
import Register from '../screens/Auth/Register'
import Header from '../shared/Header'
import React from 'react'
import ProductHeader from '../screens/Product/ProductHeader'
import Login from './../screens/Auth/Login'

const screens = {
    Login: {
        screen: Login,
        navigationOptions: {
            title : "Logging in",
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    WorksheetsList: {
        screen: WorksheetsList,
        navigationOptions: {
            headerTitle: () => <Header title={'Worksheets List'}  />,
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    ProductsList: {
        screen: ProductsList,
        navigationOptions: {
            headerTitle: () => <Header title={''}  />,
            headerStyle: { backgroundColor: '#ccc' }
        }
    },

    Product: {
        screen: Product,
        navigationOptions: {
            headerTitle: () => <ProductHeader title={''}  />,
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    Register: {
        screen: Register,
        navigationOptions: {
            headerTitle: () => <Header title={'Register'}  />,
            headerStyle: { backgroundColor: '#ccc' }
        }
    }
}

const HomeStack = createStackNavigator(screens, {
    defaultNavigationOptions: {
        headerTintColor: '#444',
        headerStyle: { backgroundColor: '#eee', height: 70 }
    }
});

export default createAppContainer(HomeStack);
