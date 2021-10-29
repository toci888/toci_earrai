import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import ProductsList from '../screens/ProductsList'
import WorksheetsList from '../screens/WorksheetsList'
import Product from '../screens/Product/Product'
import Login from '../screens/Auth/Login'
import Register from '../screens/Auth/Register'

const screens = {
    Login: {
        screen: Login,
        navigationOptions: {
            title : "Logging in",
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    ProductsList: {
        screen: ProductsList,
        navigationOptions: {
            title : "Products",
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    WorksheetsList: {
        screen: WorksheetsList,
        navigationOptions: {
            title : "Worksheets List",
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    Product: {
        screen: Product,
        navigationOptions: {
            title : "Product",
            headerStyle: { backgroundColor: '#ccc' }
        }
    },
    Register: {
        screen: Register,
        navigationOptions: {
            title : "Register",
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
