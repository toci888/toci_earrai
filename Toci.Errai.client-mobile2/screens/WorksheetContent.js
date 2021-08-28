import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Button, Text, View, TextInput } from 'react-native'
import { DataTable } from 'react-native-paper'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'

let tempColumns = 6

let testValues = ["hehe", "dupa1", "xD", "Bartłomiej"]

export default function WorksheetContent({ route, navigation }) {


    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [columns, setColumns] = useState(() => [])
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect(() => {
        let x = '[[{"id":1,"idworksheet":1,"columnindex":0,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.639163","updatedat":"2021-08-27T01:39:29.639259","idworksheetNavigation":null},{"id":2,"idworksheet":1,"columnindex":1,"rowindex":0,"value":"Product Code","createdat":"2021-08-27T01:39:29.667863","updatedat":"2021-08-27T01:39:29.667869","idworksheetNavigation":null},{"id":3,"idworksheet":1,"columnindex":2,"rowindex":0,"value":"Product Description","createdat":"2021-08-27T01:39:29.670317","updatedat":"2021-08-27T01:39:29.670323","idworksheetNavigation":null},{"id":4,"idworksheet":1,"columnindex":3,"rowindex":0,"value":"Cat.No.","createdat":"2021-08-27T01:39:29.672072","updatedat":"2021-08-27T01:39:29.672077","idworksheetNavigation":null},{"id":5,"idworksheet":1,"columnindex":4,"rowindex":0,"value":"Category","createdat":"2021-08-27T01:39:29.673673","updatedat":"2021-08-27T01:39:29.673677","idworksheetNavigation":null},{"id":6,"idworksheet":1,"columnindex":5,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.674869","updatedat":"2021-08-27T01:39:29.674872","idworksheetNavigation":null},{"id":7,"idworksheet":1,"columnindex":6,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.675956","updatedat":"2021-08-27T01:39:29.675959","idworksheetNavigation":null},{"id":8,"idworksheet":1,"columnindex":7,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.67721","updatedat":"2021-08-27T01:39:29.677212","idworksheetNavigation":null},{"id":9,"idworksheet":1,"columnindex":8,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.678238","updatedat":"2021-08-27T01:39:29.67824","idworksheetNavigation":null},{"id":10,"idworksheet":1,"columnindex":9,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.679315","updatedat":"2021-08-27T01:39:29.679319","idworksheetNavigation":null},{"id":11,"idworksheet":1,"columnindex":10,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.680545","updatedat":"2021-08-27T01:39:29.68055","idworksheetNavigation":null},{"id":12,"idworksheet":1,"columnindex":11,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.682135","updatedat":"2021-08-27T01:39:29.682139","idworksheetNavigation":null},{"id":13,"idworksheet":1,"columnindex":12,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.683281","updatedat":"2021-08-27T01:39:29.683285","idworksheetNavigation":null},{"id":14,"idworksheet":1,"columnindex":13,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.6844","updatedat":"2021-08-27T01:39:29.684402","idworksheetNavigation":null},{"id":15,"idworksheet":1,"columnindex":14,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.68555","updatedat":"2021-08-27T01:39:29.685553","idworksheetNavigation":null},{"id":16,"idworksheet":1,"columnindex":15,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.686625","updatedat":"2021-08-27T01:39:29.686627","idworksheetNavigation":null},{"id":17,"idworksheet":1,"columnindex":16,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.687611","updatedat":"2021-08-27T01:39:29.687613","idworksheetNavigation":null},{"id":18,"idworksheet":1,"columnindex":17,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.688655","updatedat":"2021-08-27T01:39:29.688658","idworksheetNavigation":null},{"id":19,"idworksheet":1,"columnindex":18,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.689701","updatedat":"2021-08-27T01:39:29.689703","idworksheetNavigation":null},{"id":20,"idworksheet":1,"columnindex":19,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.69069","updatedat":"2021-08-27T01:39:29.690692","idworksheetNavigation":null},{"id":21,"idworksheet":1,"columnindex":20,"rowindex":0,"value":"","createdat":"2021-08-27T01:39:29.691643","updatedat":"2021-08-27T01:39:29.691645","idworksheetNavigation":null}],[{"id":22,"idworksheet":1,"columnindex":0,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.692572","updatedat":"2021-08-27T01:39:29.692575","idworksheetNavigation":null},{"id":23,"idworksheet":1,"columnindex":1,"rowindex":1,"value":"ProductRecord.AccountReference","createdat":"2021-08-27T01:39:29.693551","updatedat":"2021-08-27T01:39:29.693554","idworksheetNavigation":null},{"id":24,"idworksheet":1,"columnindex":2,"rowindex":1,"value":"ProductRecord.Description","createdat":"2021-08-27T01:39:29.69453","updatedat":"2021-08-27T01:39:29.694532","idworksheetNavigation":null},{"id":25,"idworksheet":1,"columnindex":3,"rowindex":1,"value":"ProductCategory.Number","createdat":"2021-08-27T01:39:29.695491","updatedat":"2021-08-27T01:39:29.695493","idworksheetNavigation":null},{"id":26,"idworksheet":1,"columnindex":4,"rowindex":1,"value":"ProductCategory.Name","createdat":"2021-08-27T01:39:29.696531","updatedat":"2021-08-27T01:39:29.696536","idworksheetNavigation":null},{"id":27,"idworksheet":1,"columnindex":5,"rowindex":1,"value":"Company.EndOfReportBanner","createdat":"2021-08-27T01:39:29.698061","updatedat":"2021-08-27T01:39:29.698066","idworksheetNavigation":null},{"id":28,"idworksheet":1,"columnindex":6,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.699296","updatedat":"2021-08-27T01:39:29.699298","idworksheetNavigation":null},{"id":29,"idworksheet":1,"columnindex":7,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.700346","updatedat":"2021-08-27T01:39:29.700348","idworksheetNavigation":null},{"id":30,"idworksheet":1,"columnindex":8,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.701411","updatedat":"2021-08-27T01:39:29.701414","idworksheetNavigation":null},{"id":31,"idworksheet":1,"columnindex":9,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.702703","updatedat":"2021-08-27T01:39:29.702706","idworksheetNavigation":null},{"id":32,"idworksheet":1,"columnindex":10,"rowindex":1,"value":"Category Group","createdat":"2021-08-27T01:39:29.703671","updatedat":"2021-08-27T01:39:29.703673","idworksheetNavigation":null},{"id":33,"idworksheet":1,"columnindex":11,"rowindex":1,"value":"Product Category Prefix","createdat":"2021-08-27T01:39:29.704578","updatedat":"2021-08-27T01:39:29.704581","idworksheetNavigation":null},{"id":34,"idworksheet":1,"columnindex":12,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.705639","updatedat":"2021-08-27T01:39:29.705641","idworksheetNavigation":null},{"id":35,"idworksheet":1,"columnindex":13,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.706618","updatedat":"2021-08-27T01:39:29.70662","idworksheetNavigation":null},{"id":36,"idworksheet":1,"columnindex":14,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.707595","updatedat":"2021-08-27T01:39:29.707597","idworksheetNavigation":null},{"id":37,"idworksheet":1,"columnindex":15,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.708553","updatedat":"2021-08-27T01:39:29.708555","idworksheetNavigation":null},{"id":38,"idworksheet":1,"columnindex":16,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.709511","updatedat":"2021-08-27T01:39:29.709513","idworksheetNavigation":null},{"id":39,"idworksheet":1,"columnindex":17,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.710419","updatedat":"2021-08-27T01:39:29.710421","idworksheetNavigation":null},{"id":40,"idworksheet":1,"columnindex":18,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.711395","updatedat":"2021-08-27T01:39:29.711397","idworksheetNavigation":null},{"id":41,"idworksheet":1,"columnindex":19,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.71235","updatedat":"2021-08-27T01:39:29.712353","idworksheetNavigation":null},{"id":42,"idworksheet":1,"columnindex":20,"rowindex":1,"value":"","createdat":"2021-08-27T01:39:29.713643","updatedat":"2021-08-27T01:39:29.713648","idworksheetNavigation":null}]]'
        setColumns(JSON.parse(x))
        let x2 = '[[{"id":190,"idworksheet":1,"columnindex":0,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.882377","updatedat":"2021-08-27T01:39:29.882379","idworksheetNavigation":null},{"id":191,"idworksheet":1,"columnindex":1,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.883382","updatedat":"2021-08-27T01:39:29.883386","idworksheetNavigation":null},{"id":192,"idworksheet":1,"columnindex":2,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.884477","updatedat":"2021-08-27T01:39:29.88448","idworksheetNavigation":null},{"id":193,"idworksheet":1,"columnindex":3,"rowindex":9,"value":"26","createdat":"2021-08-27T01:39:29.885578","updatedat":"2021-08-27T01:39:29.88558","idworksheetNavigation":null},{"id":194,"idworksheet":1,"columnindex":4,"rowindex":9,"value":"EX_MET_Expanded Metal","createdat":"2021-08-27T01:39:29.886581","updatedat":"2021-08-27T01:39:29.886583","idworksheetNavigation":null},{"id":195,"idworksheet":1,"columnindex":5,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.887567","updatedat":"2021-08-27T01:39:29.887569","idworksheetNavigation":null},{"id":196,"idworksheet":1,"columnindex":6,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.888512","updatedat":"2021-08-27T01:39:29.888514","idworksheetNavigation":null},{"id":197,"idworksheet":1,"columnindex":7,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.889446","updatedat":"2021-08-27T01:39:29.889448","idworksheetNavigation":null},{"id":198,"idworksheet":1,"columnindex":8,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.890369","updatedat":"2021-08-27T01:39:29.890371","idworksheetNavigation":null},{"id":199,"idworksheet":1,"columnindex":9,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.891323","updatedat":"2021-08-27T01:39:29.891324","idworksheetNavigation":null},{"id":200,"idworksheet":1,"columnindex":10,"rowindex":9,"value":"Plt/Sht/Mesh","createdat":"2021-08-27T01:39:29.892282","updatedat":"2021-08-27T01:39:29.892284","idworksheetNavigation":null},{"id":201,"idworksheet":1,"columnindex":11,"rowindex":9,"value":"EX_MET","createdat":"2021-08-27T01:39:29.89327","updatedat":"2021-08-27T01:39:29.893272","idworksheetNavigation":null},{"id":202,"idworksheet":1,"columnindex":12,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.894242","updatedat":"2021-08-27T01:39:29.894244","idworksheetNavigation":null},{"id":203,"idworksheet":1,"columnindex":13,"rowindex":9,"value":"EX_MET_Expanded Metal","createdat":"2021-08-27T01:39:29.895215","updatedat":"2021-08-27T01:39:29.895217","idworksheetNavigation":null},{"id":204,"idworksheet":1,"columnindex":14,"rowindex":9,"value":"Expanded Metal","createdat":"2021-08-27T01:39:29.896143","updatedat":"2021-08-27T01:39:29.896144","idworksheetNavigation":null},{"id":205,"idworksheet":1,"columnindex":15,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.897086","updatedat":"2021-08-27T01:39:29.897087","idworksheetNavigation":null},{"id":206,"idworksheet":1,"columnindex":16,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.898004","updatedat":"2021-08-27T01:39:29.898005","idworksheetNavigation":null},{"id":207,"idworksheet":1,"columnindex":17,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.898899","updatedat":"2021-08-27T01:39:29.8989","idworksheetNavigation":null},{"id":208,"idworksheet":1,"columnindex":18,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.899959","updatedat":"2021-08-27T01:39:29.899963","idworksheetNavigation":null},{"id":209,"idworksheet":1,"columnindex":19,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.901361","updatedat":"2021-08-27T01:39:29.901365","idworksheetNavigation":null},{"id":210,"idworksheet":1,"columnindex":20,"rowindex":9,"value":"","createdat":"2021-08-27T01:39:29.902607","updatedat":"2021-08-27T01:39:29.90261","idworksheetNavigation":null}],[{"id":845,"idworksheet":1,"columnindex":0,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.45056","updatedat":"2021-08-27T01:39:30.450561","idworksheetNavigation":null},{"id":846,"idworksheet":1,"columnindex":1,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.451301","updatedat":"2021-08-27T01:39:30.451302","idworksheetNavigation":null},{"id":847,"idworksheet":1,"columnindex":2,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.452316","updatedat":"2021-08-27T01:39:30.452317","idworksheetNavigation":null},{"id":848,"idworksheet":1,"columnindex":3,"rowindex":40,"value":"108","createdat":"2021-08-27T01:39:30.453252","updatedat":"2021-08-27T01:39:30.453253","idworksheetNavigation":null},{"id":849,"idworksheet":1,"columnindex":4,"rowindex":40,"value":"F_CF_Finished_Circular Feeders","createdat":"2021-08-27T01:39:30.454138","updatedat":"2021-08-27T01:39:30.45414","idworksheetNavigation":null},{"id":850,"idworksheet":1,"columnindex":5,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.455047","updatedat":"2021-08-27T01:39:30.455047","idworksheetNavigation":null},{"id":851,"idworksheet":1,"columnindex":6,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.455803","updatedat":"2021-08-27T01:39:30.455804","idworksheetNavigation":null},{"id":852,"idworksheet":1,"columnindex":7,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.45654","updatedat":"2021-08-27T01:39:30.456541","idworksheetNavigation":null},{"id":853,"idworksheet":1,"columnindex":8,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.457357","updatedat":"2021-08-27T01:39:30.457359","idworksheetNavigation":null},{"id":854,"idworksheet":1,"columnindex":9,"rowindex":40,"value":"","createdat":"2021-08-27T01:39:30.458282","updatedat":"2021-08-27T01:39:30.458283","idworksheetNavigation":null},{"id":855,"idworksheet":1,"columnindex":10,"rowindex":40,"value":"Finished Products","createdat":"2021-08-27T01:39:30.459035","updatedat":"2021-08-27T01:39:30.459036","idworksheetNavigation":null},{"id":856,"idworksheet":1,"columnindex":11,"rowindex":40,"value":"F_CF","createdat":"2021-08-27T01:39:30.459808","updatedat":"2021-08-27T01:39:30.459809","idworksheetNavigation":null},{"id":857,"idworksheet":1,"columnindex":12,"rowindex":40,"value":"Finished_","createdat":"2021-08-27T01:39:30.4605","updatedat":"2021-08-27T01:39:30.460501","idworksheetNavigation":null},{"id":858,"idworksheet":1,"columnindex":13,"rowindex":40,"value":"F_CF_Finished_Circular Feeders","createdat":"2021-08-27T01:39:30.461211","updatedat":"2021-08-27T01:39:30.461212","idworksheetNavigation":null},{"id":859,"idworksheet":1,"columnindex":14,"rowindex":40,"value":"Circular Feeders","createdat":"2021-08-27T01:39:30.461919","updatedat":"2021-08-27T01:39:30.46192","idworksheetNavigation":null},{"id":860,"idworksheet":1,"columnindex":15,"rowindex":40,"value":"Heads","createdat":"2021-08-27T01:39:30.462814","updatedat":"2021-08-27T01:39:30.462815","idworksheetNavigation":null},{"id":861,"idworksheet":1,"columnindex":16,"rowindex":40,"value":"Numerical 1-40","createdat":"2021-08-27T01:39:30.463636","updatedat":"2021-08-27T01:39:30.463638","idworksheetNavigation":null},{"id":862,"idworksheet":1,"columnindex":17,"rowindex":40,"value":"Textual Descriptiion","createdat":"2021-08-27T01:39:30.464623","updatedat":"2021-08-27T01:39:30.464624","idworksheetNavigation":null},{"id":863,"idworksheet":1,"columnindex":18,"rowindex":40,"value":"Open Text","createdat":"2021-08-27T01:39:30.465397","updatedat":"2021-08-27T01:39:30.465398","idworksheetNavigation":null},{"id":864,"idworksheet":1,"columnindex":19,"rowindex":40,"value":"Textual Description","createdat":"2021-08-27T01:39:30.466388","updatedat":"2021-08-27T01:39:30.466389","idworksheetNavigation":null},{"id":865,"idworksheet":1,"columnindex":20,"rowindex":40,"value":"Open Text","createdat":"2021-08-27T01:39:30.467462","updatedat":"2021-08-27T01:39:30.467464","idworksheetNavigation":null}],[{"id":1139,"idworksheet":1,"columnindex":0,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.658263","updatedat":"2021-08-27T01:39:30.658264","idworksheetNavigation":null},{"id":1140,"idworksheet":1,"columnindex":1,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.658876","updatedat":"2021-08-27T01:39:30.658876","idworksheetNavigation":null},{"id":1141,"idworksheet":1,"columnindex":2,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.660532","updatedat":"2021-08-27T01:39:30.660534","idworksheetNavigation":null},{"id":1142,"idworksheet":1,"columnindex":3,"rowindex":54,"value":"208","createdat":"2021-08-27T01:39:30.662532","updatedat":"2021-08-27T01:39:30.662533","idworksheetNavigation":null},{"id":1143,"idworksheet":1,"columnindex":4,"rowindex":54,"value":"PF_CF_Part Finished_Circular Feeders","createdat":"2021-08-27T01:39:30.663455","updatedat":"2021-08-27T01:39:30.663456","idworksheetNavigation":null},{"id":1144,"idworksheet":1,"columnindex":5,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.664432","updatedat":"2021-08-27T01:39:30.664433","idworksheetNavigation":null},{"id":1145,"idworksheet":1,"columnindex":6,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.665284","updatedat":"2021-08-27T01:39:30.665286","idworksheetNavigation":null},{"id":1146,"idworksheet":1,"columnindex":7,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.665966","updatedat":"2021-08-27T01:39:30.665967","idworksheetNavigation":null},{"id":1147,"idworksheet":1,"columnindex":8,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.666602","updatedat":"2021-08-27T01:39:30.666603","idworksheetNavigation":null},{"id":1148,"idworksheet":1,"columnindex":9,"rowindex":54,"value":"","createdat":"2021-08-27T01:39:30.667208","updatedat":"2021-08-27T01:39:30.667209","idworksheetNavigation":null},{"id":1149,"idworksheet":1,"columnindex":10,"rowindex":54,"value":"Finished Products","createdat":"2021-08-27T01:39:30.667824","updatedat":"2021-08-27T01:39:30.667825","idworksheetNavigation":null},{"id":1150,"idworksheet":1,"columnindex":11,"rowindex":54,"value":"PF_CF","createdat":"2021-08-27T01:39:30.668449","updatedat":"2021-08-27T01:39:30.66845","idworksheetNavigation":null},{"id":1151,"idworksheet":1,"columnindex":12,"rowindex":54,"value":"Part Finished_","createdat":"2021-08-27T01:39:30.669057","updatedat":"2021-08-27T01:39:30.669057","idworksheetNavigation":null},{"id":1152,"idworksheet":1,"columnindex":13,"rowindex":54,"value":"PF_CF_Part Finished_Circular Feeders","createdat":"2021-08-27T01:39:30.669679","updatedat":"2021-08-27T01:39:30.669679","idworksheetNavigation":null},{"id":1153,"idworksheet":1,"columnindex":14,"rowindex":54,"value":"Circular Feeders","createdat":"2021-08-27T01:39:30.670284","updatedat":"2021-08-27T01:39:30.670285","idworksheetNavigation":null},{"id":1154,"idworksheet":1,"columnindex":15,"rowindex":54,"value":"Part Finished Status","createdat":"2021-08-27T01:39:30.670909","updatedat":"2021-08-27T01:39:30.670909","idworksheetNavigation":null},{"id":1155,"idworksheet":1,"columnindex":16,"rowindex":54,"value":"Open Text","createdat":"2021-08-27T01:39:30.671526","updatedat":"2021-08-27T01:39:30.671527","idworksheetNavigation":null},{"id":1156,"idworksheet":1,"columnindex":17,"rowindex":54,"value":"Textual Description","createdat":"2021-08-27T01:39:30.672143","updatedat":"2021-08-27T01:39:30.672144","idworksheetNavigation":null},{"id":1157,"idworksheet":1,"columnindex":18,"rowindex":54,"value":"Open Text","createdat":"2021-08-27T01:39:30.673168","updatedat":"2021-08-27T01:39:30.673169","idworksheetNavigation":null},{"id":1158,"idworksheet":1,"columnindex":19,"rowindex":54,"value":"Textual Description","createdat":"2021-08-27T01:39:30.673793","updatedat":"2021-08-27T01:39:30.673793","idworksheetNavigation":null},{"id":1159,"idworksheet":1,"columnindex":20,"rowindex":54,"value":"Open Text","createdat":"2021-08-27T01:39:30.674447","updatedat":"2021-08-27T01:39:30.674448","idworksheetNavigation":null}]]';
        setworksheetContent(JSON.parse(x2))
        setloading(false)

        /*fetch("https://localhost:44326/api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId'))
            .then(response => response.json())
            .then(response => {
                console.log(response)
                console.log(JSON.stringify(response))
                setColumns(response)
                setloading(false)
            }).catch(error => {
                console.log(error)

            })*/

    }, [])

    const searchForData = () => {
        fetch("https://localhost:44326/api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue)
        .then(response => response.json())
        .then(response => {
            console.log(response)
            console.log(JSON.stringify(response))
            setworksheetContent(response)
        }).catch(error => {
            console.log(error)


        })
    }

    const showRecordData = (rowIndex) => {

        console.log(worksheetContent[rowIndex])


        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            workSheetRecord: worksheetContent[rowIndex],
            connectService: connectService
        })



    }


    const filterContent = (e) => {

        console.log(e.target.value);
        setfilteredValue(e.target.value)

        if(e.target.value.length < 3) return

        searchForData()

        //let filtered = worksheetContent.filter(item => item.name.toLowerCase().includes(e.target.value.toLowerCase()))
        //setdisplayedworksheetContent(filtered)
    }

    const testChangeValue = (rowIndex, columnIndex) => {
        console.log(rowIndex, columnIndex)

        let random = Math.floor(Math.random() * (testValues.length - 0)) + 0

        let val = testValues[random]


        const tempContent = [...worksheetContent]
        console.log(tempContent)

        tempContent[rowIndex][columnIndex].value = val
        console.log(connectService.isConnectedFunc())
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(tempContent[rowIndex][columnIndex])
        } else {
            connectService.updateRecord(tempContent[rowIndex][columnIndex])
        }

        setworksheetContent(tempContent)

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    if (loading) {
        return (
            <View style={globalStyles.loading}>
                <Text style={globalStyles.loadingText}>Loading..</Text>
            </View>
        )
    }

    return (
        <View style={globalStyles.content}>
            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}

            <Text style={globalStyles.chooseWorkbookHeader}> Worksheet Content (Table) </Text>

            <View>

                <TextInput
                    value={filteredValue}
                    style={globalStyles.inputStyle}
                    onChange={($event) => filterContent($event)}
                    placeholder="Filter.."
                />

            </View>

            <View>

                <DataTable>

                    {/* Chwilowo tylko kilka column widocznych */}

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns[0].map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns[1].map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > {column.value} </DataTable.Title>
                        })}

                    </DataTable.Header>

                    {
                        worksheetContent.map( (row, rowIndex) => {
                            return(<DataTable.Row key={ rowIndex } >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    return <DataTable.Cell
                                                key={column.id}
                                                onPress={ () => showRecordData(rowIndex) }
                                                // onPress={ () => testChangeValue(rowIndex, columnIndex) }
                                                style={globalStyles.cell}>
                                                {column.value}
                                            </DataTable.Cell>
                                } ) }
                            </DataTable.Row>)
                        } )
                    }

                </DataTable>

            </View>
            <View style={{paddingTop: 45}}>
                <Button title="ADD NEW RECORD" />
            </View>

        </View>
    )
}
