* https://www.npmjs.com/package/react-export-excel
* npm install react-export-excel --save
* import Excel from '../../UI/Export/Excel';
* *
 ```js
           <Excel
            data={{
              Sheet1: props.LeaveDataObj
            }}
            buttontext="Export to Excel"
          />
```



## component
```js
import React from "react";
import ReactExport from "react-export-excel";
import Button from "../Button/ButtonComponent";
import PropTypes from "prop-types";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

const Excel = ({ filename, buttontext, data, headers }) => {
  const mainexcel = (data) => {
    let sheetdetails = [];
    for (let element in data) {
      sheetdetails.push(element);
    }
    return sheetdetails;
  };

  const getExcelColumns = (data, headers) => {
    if (headers !== undefined && headers !== null) {
      return headers;
    }
    let excelheaders = [];
    for (let element in data) {
      excelheaders.push(element);
    }
    console.log(excelheaders);
    return excelheaders;
  };
  const newId = (base) => {
    if (filename && filename !== "") {
      return filename;
    }
    return [
      Math.random,
      function () {
        return newId.last
          ? window.windowId.last + Math.random()
          : Math.random();
      },
      Math.random,
      Date.now,
      Math.random,
    ]
      .map(function (fn) {
        return fn()
          .toString(base || 16 + Math.random() * 20)
          .substr(-8);
      })
      .join("");
  };
  return (
    <div>
      <ExcelFile filename={newId(36)} element={<Button>{buttontext}</Button>}>
        {mainexcel(data).length > 0 &&
          mainexcel(data).map((sheetData, index) => {
            return (
              <ExcelSheet key={index} data={data[sheetData]} name={sheetData}>
                {getExcelColumns(data[sheetData][0], headers).map(
                  (coldata, colindex) => {
                    return (
                      <ExcelColumn
                        key={colindex}
                        label={coldata.toString().toUpperCase()}
                        value={coldata}
                      />
                    );
                  },
                )}
              </ExcelSheet>
            );
          })}
      </ExcelFile>
    </div>
  );
};
Excel.propTypes = {
  filename: PropTypes.string,
  buttontext: PropTypes.string,
};
export default Excel;


```
