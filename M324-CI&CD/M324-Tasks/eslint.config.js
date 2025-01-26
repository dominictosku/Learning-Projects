// eslint.config.js
import globals from 'globals';
import pluginJs from '@eslint/js';

export default [
  {
    languageOptions: {
      globals: {
        ...globals.browser,
        ...globals.mocha, // Include Mocha global variables
      },
    },
  },
  pluginJs.configs.recommended,
];
