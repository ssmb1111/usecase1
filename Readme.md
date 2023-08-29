# RestCountries Simple API

## Application description
This application connects to RestCountries REST API and gets all countries. The response is limited to 10 results.

You have a number of filtering options, such as:
- Common name filter,
- Population filter (in millions),
- Order by common name.

## Build and run
Please make sure you have .NET 6 SDK installed.

To build this application, use either `dotnet build` or open a solution in Visual Studio and select Build -> Build Solution.

To run this application, use `dotnet run` or open a solution in Visual Studio and select Debug -> Start Without Debugging.

If you select an application in a Development environment, Swagger will launch for your convenience.

## Examples

### 1. <URL\>/restcountries/all
Explanation: The only endpoint provided by this API, returning a list of countries provided by RestCountries.

Result: List of the 10 first countries recieved from RestCountries.

Example result:
```
[
    {
        "name": {
            "common": "South Africa",
            "official": "Republic of South Africa",
            "nativeName": {
                "afr": {
                    "common": "South Africa",
                    "official": "Republiek van Suid-Afrika"
                },
                "eng": {
                    "common": "South Africa",
                    "official": "Republic of South Africa"
                },
                "nbl": {
                    "common": "Sewula Afrika",
                    "official": "IRiphabliki yeSewula Afrika"
                },
                (...)
]
```

### 2. <URL\>/restcountries/all?nameFilter=republic
Explanation: Get countries with common name containing "republic". This search is case insensitive.

Result: 3 countries - Republic of the Congo, Dominican Republic and Central African Republic.

Example result:
```
[
    {
        "name": {
            "common": "Republic of the Congo",
            (...)
        },
        (...)
    },
    {
        "name": {
            "common": "Dominican Republic",
            (...)
        },
        (...)
    },
    {
        "name": {
            "common": "Central African Republic",
            (...)
        },
        (...)
    }
]
```

### 3. <URL\>/restcountries/all?nameFilter=REPUBLIC
Explanation: Get countries with common name containing "republic". This search is case insensitive.

Result: 3 countries - Republic of the Congo, Dominican Republic and Central African Republic.

Example result:
```
[
    {
        "name": {
            "common": "Republic of the Congo",
            (...)
        },
        (...)
    },
    {
        "name": {
            "common": "Dominican Republic",
            (...)
        },
        (...)
    },
    {
        "name": {
            "common": "Central African Republic",
            (...)
        },
        (...)
    }
]
```

### 4. <URL\>/restcountries/all?maxPopulationInMilions=1
Explanation: Get countries with population less than 1 milion.

Result: 10 countries with population less than 1 milion.

Example result:
```
[
    {
        "name": {
            "common": "Svalbard and Jan Mayen",
            (...)
        },
        (...)
        "population": 2562,
        (...)
    },
    {
        "name": {
            "common": "Samoa",
            (...)
        },
        (...)
        "population": 198410,
        (...)
    },
    {
        "name": {
            "common": "Saint Kitts and Nevis",
            (...)
        },
        (...)
        "population": 53192,
        (...)
    }
]
```

### 5. <URL\>/restcountries/all?sortOrder=abc
Explanation: Sortorder accepts only two values: 'ascend' or 'descend'. 

```
Result: Status: 500 Internal Server Error
```

### 6. <URL\>/restcountries/all?sortOrder=descend

Result: 10 last countries alphabetically.

Example result:
```
[
    {
        "name": {
            "common": "Zimbabwe",
            "official": "Republic of Zimbabwe",
        (...)
    },
    {
        "name": {
            "common": "Zambia",
            "official": "Republic of Zambia",
        (...)
    },
    {
        "name": {
            "common": "Western Sahara",
            "official": "Sahrawi Arab Democratic Republic",
        (...)
    },
    {
        "name": {
            "common": "Yemen",
            "official": "Republic of Yemen",
        (...)
    },
    (... 6 more)
]
```

### 7. <URL\>/restcountries/all?sortOrder=ascend

Result: 10 first countries alphabetically.

Example result:
```
[
    {
        "name": {
            "common": "Afghanistan",
            "official": "Islamic Republic of Afghanistan",
        (...)
    },
    {
        "name": {
            "common": "Aland Islands",
            "official": "Aland Islands",
        (...)
    },
    {
        "name": {
            "common": "Albania",
            "official": "Republic of Albania",
        (...)
    },
    {
        "name": {
            "common": "Algeria",
            "official": "People's Democratic Republic of Algeria",
        (...)
    },
    (... 6 more)
]
```

### 8. <URL\>/restcountries/all?nameFilter=republic&maxPopulationInMilions=5&sortOrder=ascend
Explanation: Get countries with common name containing "republic", maximum population 5 milion and order them in ascending order by common name.

Result: Only 1 country - Central African Republic.

Example result:
```
[
    {
        "name": {
            "common": "Central African Republic",
            "official": "Central African Republic",
            "nativeName": {
                "fra": {
                    "common": "République centrafricaine",
                    "official": "République centrafricaine"
                },
                "sag": {
                    "common": "Bêafrîka",
                    "official": "Ködörösêse tî Bêafrîka"
                }
            }
        },
        (...)
        "population": 4829764,
        (...)
    }
]
```

### 9. <URL\>/restcountries/all?nameFilter=republic&maxPopulationInMilions=10&sortOrder=ascend
Explanation: Get countries with common name containing "republic", maximum population 10 milion and order them in ascending order by common name.

Result: 2 countries - Central African Republic and Republic of the Congo.

Example result:
```
[
    {
        "name": {
            "common": "Central African Republic",
            (...)
        },
        (...)
        "population": 4829764,
        (...)
    },
    {
        "name": {
            "common": "Republic of the Congo",
            (...)
        },
        (...)
        "population": 5657000,
        (...)
    }
]
```

### 10. <URL\>/restcountries/all?nameFilter=republic&maxPopulationInMilions=10&sortOrder=descend
Explanation: Get countries with common name containing "republic", maximum population 10 milion and order them in descending order by common name.

Result: 2 countries - Central African Republic and Republic of the Congo.

Example result:
```
[
    {
        "name": {
            "common": "Republic of the Congo",
            (...)
        },
        (...)
        "population": 5657000,
        (...)
    },
    {
        "name": {
            "common": "Central African Republic",
            (...)
        },
        (...)
        "population": 4829764,
        (...)
    }
]
```