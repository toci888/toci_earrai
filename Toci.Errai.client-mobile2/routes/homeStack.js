
import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import Home from '../screens/Home'
import ReviewDetails from '../screens/ReviewDetails'


const screens = {
    Home: {
        screen: Home,
        navigationOptions: {
            title : "Home / Workbooks",
            headerStyle: { backgroundColor: '#ccc', color: '#ffffff' }
            // headerTitle : () => <Header />,
        }
    },
    ReviewDetails: {
        screen: ReviewDetails,
        navigationOptions: {
            title : "Worksheets",
            headerStyle: { backgroundColor: '#ccc', color: '#66b3ff' }
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
