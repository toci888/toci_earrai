import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import Home from '../screens/Home'
import ProductsList from '../screens/WorksheetContent'
import WorksheetsList from '../screens/WorksheetsList'
import WorksheetRecord from '../screens/WorksheetRecord'
import Login from '../screens/Login'
import Register from '../screens/Register'

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
    WorksheetRecord: {
        screen: WorksheetRecord,
        navigationOptions: {
            title : "Product",
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

    Home: {
        screen: Home,
        navigationOptions: {

            title : "Home / Workbooks",
            // headerStyle: { backgroundColor: '#ccc', color: '#ffffff' },
            // headerTitle : () =>
            // <View style={{flex: 1, flexDirection:'row', flexWrap:'wrap'}}>
            //     <Text style={{textAlign: 'right'}}>Home / Workbooks</Text>

            //     <View style={{marginLeft: 50, marginRight: 50, flexDirection:'row', flexWrap:'wrap', textAlign: 'flex-end'}}>
            //         <Button title="Login" onPress={() => navigation.navigate('Login')}/>
            //         <Button title="Register" onPress={() => navigation.navigate('Register')}/>
            //     </View>

            // </View>,

            // <View style={{flexDirection:'row',justifyContent : 'space-between'}}>
            //     <View style={{flexDirection:'row',justifyContent : 'space-between'}}>
            //         <Text style={globalStyles.unityName, {fontSize: 20}}>Home / Workbooks1</Text>
            //         {/* <Text style={globalStyles.subInfo}>Home / Workbooks2</Text> */}
            //     </View>
            //     <View style={{flexDirection: 'row', justifyContent: 'space-between'}}>
            //         <Text style={{marginRight: 20}} onPress={() => navigation.navigate('Login')}>Login</Text>
            //         <Text onPress={() => navigation.navigate('Register')}>Register</Text>
            //     </View>
            // </View>

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
