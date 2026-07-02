
import { defineConfig } from "vite";

export default defineConfig({
  build: {
    lib: {
      entry: "src/dawoe-oembed-picker.ts", // your web component source file
      formats: ["es"],
    },
    outDir: "../wwwroot/App_Plugins/Dawoe.OEmbedPickerPropertyEditor", // all compiled files will be placed here
    emptyOutDir: true,
    sourcemap: true,
    rollupOptions: {
      external: [/^@umbraco/], // ignore the Umbraco Backoffice package in the build
    },
  },
  base: "/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/", // the base path of the app in the browser (used for assets)
});
