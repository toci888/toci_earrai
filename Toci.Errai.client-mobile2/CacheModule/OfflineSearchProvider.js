import { createFilterDto, getAvailableTypeForWorksheet, getTypesOfSearchForWorksheet } from '../screens/ProductsList_Config';
import RestClient from '../shared/RestClient';
import {    getAvailableValuesForSelectedOptionUrl } from '../shared/RequestConfig';
import { environment } from '../environment';

export default class OfflineSearchProvider
{
    restClient = new RestClient();

  
    availableValues = new Array(10);

    getAvailableValues = () => {
        
        for (var i = 1; i < 10; i++)
        {
            const typesOfSearchArray = getTypesOfSearchForWorksheet(i);
            const worksheetSearchOptions = new Array();
//console.log('teraz ja sie pobawie', typesOfSearchArray);
            for (var j = 0; j < typesOfSearchArray.length; j++)
            {
                const filterDto = createFilterDto(i, typesOfSearchArray[j])
                const filterDtoReplaced = this.dbNameReplacer(filterDto)

                /*this.restClient.POST(getAvailableValuesForSelectedOptionUrl, filterDtoReplaced).then(searchValues => {

                    worksheetSearchOptions.push(searchValues);

                    console.log('wyniu', i, searchValues);

                    if (i == 9)// && j == typesOfSearchArray.length - 1)
                        console.log('test 123', this.availableValues);
                }).catch(error => {
                    console.log(error)
                }).finally(() => {
                    
                });*/
            }

            this.availableValues[i] = worksheetSearchOptions;
        }
console.log('all ther data', this.availableValues);
        return this.availableValues;
    }

    dbNameReplacer(value_) {
        if(value_.name == "DimA") value_.name = "SizeA"
        if(value_.name == "DimB") value_.name = "SizeB"
        if(value_.name == "OD") value_.name = "ChsOd"
        return value_;
    }
}