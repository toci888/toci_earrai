
import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import Home from '../screens/Home'
import ReviewDetails from '../screens/ReviewDetails'


const screens = {
    Home: {
        screen: Home,
        navigationOptions: {
            title : "Home",
            headerStyle: { backgroundColor: '#333', color: "white" }
            // headerTitle : () => <Header />,
        }
    },
    ReviewDetails: {
        screen: ReviewDetails,
        navigationOptions: {
            title : "Details",
            headerStyle: { backgroundColor: '#eee' }
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
