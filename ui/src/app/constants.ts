export const Constants = {
  Images: {},
  Regex: {
    OnlyLetters: "([A-Za-ÿ][-,a-z. ']+[ ]*)+",
    Password: '^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&_])[A-Za-z\\d@$!%*?&_]{8,}$',
    Phone: '^(1\\s?)?((\\([0-9]{3}\\))|[0-9]{3})[\\s\\-]?[\\0-9]{3}[\\s\\-]?[0-9]{4}$',
    Email: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\s*$/,
    UsZipCode: '^[0-9]{5}(?:-[0-9]{4})?$'
  },
  SkuPattern: 'AAA-AAA'
};
