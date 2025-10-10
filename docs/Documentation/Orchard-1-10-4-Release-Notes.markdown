# Orchard 1.10.4 Release Notes

Published: 10/10/2025

**NOTE**: Unless you absolutely have to avoid any breaking change, we recommend that you use 1.11 (to be released later in 2025) instead.

## Who should use this software?

This software is in version 1.10.4, the last version published from the `1.10.x` branch.
The code is in a stable state and constitutes a solid foundation for building applications, themes and modules.

You are allowed to use this software in any way that is compatible with the new BSD license, including commercial derivative work.

## Breaking Changes

There are no known breaking changes as part of this release [compared to 1.10](Orchard-1-10-Release-Notes.markdown).

## New Features

* [#6793](https://github.com/OrchardCMS/Orchard/issues/6793): Add content-independent culture selector shape for front-end localization ([#8784](https://github.com/OrchardCMS/Orchard/pull/8784)).
* [#8012](https://github.com/OrchardCMS/Orchard/issues/8012): Add Excel export functionality to DynamicForms for data export ([#8016](https://github.com/OrchardCMS/Orchard/pull/8016)).
* [#8213](https://github.com/OrchardCMS/Orchard/pull/8213): Added a Projection Filter for `StringField`.
* [#8225](https://github.com/OrchardCMS/Orchard/issues/8225): Add checkbox to StringFilterForm to allow skipping the filter when the value is empty ([#8781](https://github.com/OrchardCMS/Orchard/pull/8781)).
* [#8259](https://github.com/OrchardCMS/Orchard/issues/8259): Add token support for request headers ([#8263](https://github.com/OrchardCMS/Orchard/pull/8263)).
* [#8280](https://github.com/OrchardCMS/Orchard/issues/8280): Add `RemovePartFromContentTypeStep` for recipes for removing a content part from a type.
* [#8282](https://github.com/OrchardCMS/Orchard/issues/): Add field removal to `RemoveFromContentTypeStep` for recipes for removing a field from a content part.
* [#8350](https://github.com/OrchardCMS/Orchard/issues/8350): Add tokenizable default value support to `ContentPickerField` ([#8351](https://github.com/OrchardCMS/Orchard/pull/8351)).
* [#8381](https://github.com/OrchardCMS/Orchard/issues/8381): Add token-based sort criteria for dynamic query ordering ([#8382](https://github.com/OrchardCMS/Orchard/pull/8382)).
* [#8437](https://github.com/OrchardCMS/Orchard/issues/8437): Add a workflow event activity that triggers on the first content update to enable more granular workflow automation ([#8438](https://github.com/OrchardCMS/Orchard/pull/8438)).
* [#8465](https://github.com/OrchardCMS/Orchard/issues/8465): Add culture selection in widgets page for better localization support ([#8466](https://github.com/OrchardCMS/Orchard/pull/8466)).
* [#8480](https://github.com/OrchardCMS/Orchard/issues/8480): Add "Exclude children" option for the Taxonomy Term Filter to allow more granular filtering ([#8481](https://github.com/OrchardCMS/Orchard/pull/8481)).
* [#8500](https://github.com/OrchardCMS/Orchard/issues/8500): Add HtmlDecode token for decoding encoded HTML content in templates ([#8501](https://github.com/OrchardCMS/Orchard/pull/8501)).
* [#8537](https://github.com/OrchardCMS/Orchard/issues/8537): Add support for cloning layout elements in Orchard.Layouts to simplify layout duplication and speed up page design ([#8538](https://github.com/OrchardCMS/Orchard/pull/8538)).
* [#8539](https://github.com/OrchardCMS/Orchard/pull/8539): Add specific permission (`MayEditContentOwner`) to change content item owner for better security control.
* [#8565](https://github.com/OrchardCMS/Orchard/issues/8565): Add Delete and Unpublish buttons in the content editors for easier content management ([#8566](https://github.com/OrchardCMS/Orchard/pull/8566)).
* [#8569](https://github.com/OrchardCMS/Orchard/issues/8569): Add Blog Post search feature to improve content discoverability ([#8570](https://github.com/OrchardCMS/Orchard/pull/8570)).
* [#8657](https://github.com/OrchardCMS/Orchard/issues/8657): Add role event activities and handlers for workflows to enable role-based triggers ([#8658](https://github.com/OrchardCMS/Orchard/pull/8658)).
* [#8666](https://github.com/OrchardCMS/Orchard/issues/8666): Add "No term selection" option in TaxonomyField to prevent validation errors ([#8667](https://github.com/OrchardCMS/Orchard/pull/8667)).
* [#8668](https://github.com/OrchardCMS/Orchard/pull/8668): Added the HtmlSnippets plugin to the TinyMCE editor.
* [#8678](https://github.com/OrchardCMS/Orchard/issues/8678): Add TinyMCE content links plugin for improved content editing ([#8679](https://github.com/OrchardCMS/Orchard/pull/8679)).
* [#8717](https://github.com/OrchardCMS/Orchard/pull/8717): Update XML helper to support storing and parsing Guid values in infoset.
* [#8718](https://github.com/OrchardCMS/Orchard/issues/8718): Added maximum length setting to TextField and TitlePart ([#8719](https://github.com/OrchardCMS/Orchard/pull/8719)).
* [#8730](https://github.com/OrchardCMS/Orchard/pull/8730): Added ability to Projections to include localizations of selected Taxonomy Terms in filters for multilingual support.
* [#8752](https://github.com/OrchardCMS/Orchard/issues/8752): Added the ability to publish/unpublish menu items in the menu editor ([#8807](https://github.com/OrchardCMS/Orchard/pull/8807)).
* [#8755](https://github.com/OrchardCMS/Orchard/issues/8755): Add chain to Slug token to enable TextTokens for Autoroute configuration ([#8755](https://github.com/OrchardCMS/Orchard/pull/8755)).
* [#8828](https://github.com/OrchardCMS/Orchard/issues/8828): Expose Redis API to clear multiple keys using wildcard syntax ([#8829](https://github.com/OrchardCMS/Orchard/pull/8829)).
* [#8832](https://github.com/OrchardCMS/Orchard/issues/8832): Add LazyLoadConvention for NHibernate to optimize entity loading ([#8833](https://github.com/OrchardCMS/Orchard/pull/8833)).

## Performance

* [#8196](https://github.com/OrchardCMS/Orchard/issues/8196): Add database indexes to `CommonPartRecord` and `CommonPartVersionRecord` tables to improve query performance ([#8210](https://github.com/OrchardCMS/Orchard/pull/8210)).
* [#8207](https://github.com/OrchardCMS/Orchard/pull/8207): Improve performance of `DefaultContentManager` by optimizing content item loading and reducing redundant database queries.
* [#8284](https://github.com/OrchardCMS/Orchard/issues/8284): SSL and culture settings caching for improved performance ([#8289](https://github.com/OrchardCMS/Orchard/pull/8289)).
* [#8354](https://github.com/OrchardCMS/Orchard/issues/8354): Optimize settings loading by preventing multiple hits on `Settings_ShellDescriptorRecord` ([#8355](https://github.com/OrchardCMS/Orchard/pull/8355)).
* [#8359](https://github.com/OrchardCMS/Orchard/issues/8359): Improve AutoroutePart handling for more efficient route generation ([#8360](https://github.com/OrchardCMS/Orchard/pull/8360)).
* [#8361](https://github.com/OrchardCMS/Orchard/issues/8361): Add new database indexes to CommonPartRecord tables to improve query performance and reduce load times for content retrieval ([#8362](https://github.com/OrchardCMS/Orchard/pull/8362)).
* [#8370](https://github.com/OrchardCMS/Orchard/issues/8370): Save `MemberBindingRecord`s in memory to reduce database calls ([#8371](https://github.com/OrchardCMS/Orchard/pull/8371)).
* [#8372](https://github.com/OrchardCMS/Orchard/issues/8372): Cache the list of configured layers to improve rendering performance ([#8373](https://github.com/OrchardCMS/Orchard/pull/8373)).
* [#8374](https://github.com/OrchardCMS/Orchard/issues/8374): Memorize query results in the blog service to reduce repeated database queries.
* [#8459](https://github.com/OrchardCMS/Orchard/pull/8459): Added indexes to `CommonPartRecord` and `IdentityPartRecord` to ensure schema consistency.
* [#8472](https://github.com/OrchardCMS/Orchard/pull/8472): Upgrade YamlDotNet from 9.1.3 to 11.1.1 for improved YAML parsing performance.
* [#8488](https://github.com/OrchardCMS/Orchard/pull/8488): Update NHibernate to improve ORM performance and compatibility.
* [#8674](https://github.com/OrchardCMS/Orchard/issues/8674): Optimize shape table sorting for better rendering performance ([#8676](https://github.com/OrchardCMS/Orchard/pull/8676)).
* [#8675](https://github.com/OrchardCMS/Orchard/issues/8675): Improve ExtensionManager performance for faster module loading ([#8677](https://github.com/OrchardCMS/Orchard/pull/8677)).
* [#8689](https://github.com/OrchardCMS/Orchard/issues/8689): Add in-memory caching to INavigationFilters for better performance when the same navigation is rendered in multiple places ([#8690](https://github.com/OrchardCMS/Orchard/pull/8690)).
* [#8692](https://github.com/OrchardCMS/Orchard/issues/8692): Prevent unnecessary queries from LocalizationPart to improve performance ([#8693](https://github.com/OrchardCMS/Orchard/pull/8693)).
* [#8706](https://github.com/OrchardCMS/Orchard/issues/8706): Cache CultureRecords by both Id and Name to improve localization performance ([#8708](https://github.com/OrchardCMS/Orchard/pull/8708)).

## Improvements

* [#6518](https://github.com/OrchardCMS/Orchard/pull/6518): Add a button in the Media Library to select all items for easier bulk operations.
* [#6792](https://github.com/OrchardCMS/Orchard/pull/6792): Enforce stricter file and folder name validation in Media Library for security.
* [#6821](https://github.com/OrchardCMS/Orchard/issues/6821): Use alias in import/export for `TaxonomyId` within `TaxonomyElement` ([#6828](https://github.com/OrchardCMS/Orchard/pull/6828)).
* [#8007](https://github.com/OrchardCMS/Orchard/issues/8007): Upgrade all projects to target .NET Framework 4.8 for better compatibility and security ([#8444](https://github.com/OrchardCMS/Orchard/pull/8444)).
* [#8198](https://github.com/OrchardCMS/Orchard/issues/8198): Consolidate `UpdateFrom4` changes into `Create` in Autoroute migrations ([#8217](https://github.com/OrchardCMS/Orchard/pull/8217)).
* [#8232](https://github.com/OrchardCMS/Orchard/issues/8232): Add warnings when a Projection Query has an empty Filter Group ([#8813](https://github.com/OrchardCMS/Orchard/pull/8813)).
* [#8233](https://github.com/OrchardCMS/Orchard/issues/8233): Add return URL when clicking on content hosted in a content picker ([#8234](https://github.com/OrchardCMS/Orchard/pull/8234)).
* [#8238](https://github.com/OrchardCMS/Orchard/issues/8238): Use `CreateRouteValues` for creation routes in `Orchard.Core.Contents` ([#8241](https://github.com/OrchardCMS/Orchard/pull/8241)).
* [#8243](https://github.com/OrchardCMS/Orchard/issues/8243): Add `Options.SelectedCulture` to RouteData to enable culture-aware route handling ([#8244](https://github.com/OrchardCMS/Orchard/pull/8244)).
* [#8258](https://github.com/OrchardCMS/Orchard/issues/8258): Change returnUrl from absolute URL to relative URL to improve security and consistency ([#8265](https://github.com/OrchardCMS/Orchard/pull/8265)).
* [#8299](https://github.com/OrchardCMS/Orchard/pull/8299): Switch Markdown processing to Markdig for improved rendering.
* [#8308](https://github.com/OrchardCMS/Orchard/pull/8308): Remove `ArchiveLaterTask` when the associated content item is deleted or destroyed.
* [#8323](https://github.com/OrchardCMS/Orchard/pull/8323): Normalize behavior in the Taxonomies admin views to ensure consistent behavior of action links.
* [#8328](https://github.com/OrchardCMS/Orchard/issues/8328): Make images recognizable in the Media Library Admin UI even if they are white on a transparent background ([#8329](https://github.com/OrchardCMS/Orchard/pull/8329)).
* [#8346](https://github.com/OrchardCMS/Orchard/issues/8346): Add permissions for admin search to allow granular access control ([#8345](https://github.com/OrchardCMS/Orchard/pull/8345)).
* [#8380](https://github.com/OrchardCMS/Orchard/pull/8380): Update the UI for projections to improve usability.
* [#8383](https://github.com/OrchardCMS/Orchard/issues/8383): Process ignored paths in `OutputCache` with awareness of RequestUrlPrefix for correct routing ([#8384](https://github.com/OrchardCMS/Orchard/pull/8384)).
* [#8386](https://github.com/OrchardCMS/Orchard/issues/8386): Upgrade host resolution logic for improved multi-tenant support ([#8387](https://github.com/OrchardCMS/Orchard/pull/8387)).
* [#8399](https://github.com/OrchardCMS/Orchard/issues/8399): Update DistributedLockService to improve distributed task synchronization ([#8398](https://github.com/OrchardCMS/Orchard/pull/8398)).
* [#8419](https://github.com/OrchardCMS/Orchard/pull/8419): Allow downstream methods to set default values for improved flexibility in boolean model binding.
* [#8445](https://github.com/OrchardCMS/Orchard/issues/8445): Update NuGet libraries to latest versions for improved stability and security ([#8446](https://github.com/OrchardCMS/Orchard/pull/8446)).
* [#8457](https://github.com/OrchardCMS/Orchard/pull/8457): Upgraded `Moq` and `Microsoft.IdentityModel`.
* [#8467](https://github.com/OrchardCMS/Orchard/issues/8467): Show disable action for deprecated Core features to improve feature management ([#8468](https://github.com/OrchardCMS/Orchard/pull/8468)).
* [#8489](https://github.com/OrchardCMS/Orchard/pull/8489): Add default settings for projections to simplify configuration ([#8497](https://github.com/OrchardCMS/Orchard/pull/8497)).
* [#8502](https://github.com/OrchardCMS/Orchard/issues/8502): Set SSL redirection as permanent for SEO optimization ([#8503](https://github.com/OrchardCMS/Orchard/pull/8503)).
* [#8512](https://github.com/OrchardCMS/Orchard/issues/8512): Fix various typos in T-strings.
* [#8517](https://github.com/OrchardCMS/Orchard/pull/8517): Added Event Descriptor to the Audit Trail context to allow handlers know more about source of the event.
* [#8549](https://github.com/OrchardCMS/Orchard/pull/8549): Add routing metadata for UserPart for action links to point to the correct controller.
* [#8571](https://github.com/OrchardCMS/Orchard/issues/8571): Allow RecipeManager to adjust execution timeout for long-running recipes ([#8572](https://github.com/OrchardCMS/Orchard/pull/8572)).
* [#8599](https://github.com/OrchardCMS/Orchard/issues/8599): Support nullable values in Boolean Fields for better flexibility ([#8600](https://github.com/OrchardCMS/Orchard/pull/8600)).
* [#8617](https://github.com/OrchardCMS/Orchard/pull/8617): Upgrade OWIN packages for improved security and compatibility.
* [#8629](https://github.com/OrchardCMS/Orchard/issues/8629): Add cacheKey parameter to distinguish between AJAX and normal requests in Output Cache ([#8630](https://github.com/OrchardCMS/Orchard/pull/8630)).
* [#8633](https://github.com/OrchardCMS/Orchard/pull/8633): Update SharpZipLib to version 1.3.3 for improved compression handling.
* [#8639](https://github.com/OrchardCMS/Orchard/issues/8639): Add hints to display technical names in content type and field definition editors for easier configuration ([#8640](https://github.com/OrchardCMS/Orchard/pull/8640)).
* [#8650](https://github.com/OrchardCMS/Orchard/issues/8650): Add sequential upload parameter for importing items to the Media Library to prevent UI freezing ([#8650](https://github.com/OrchardCMS/Orchard/pull/8650)).
* [#8680](https://github.com/OrchardCMS/Orchard/pull/8680): Added missing `OrchardFeature` attributes in Orchard.Roles for proper feature registration.
* [#8691](https://github.com/OrchardCMS/Orchard/issues/8691): Replace SmtpClient with MailKit for sending emails to modernize email handling ([#8707](https://github.com/OrchardCMS/Orchard/pull/8707)).
* [#8720](https://github.com/OrchardCMS/Orchard/issues/8720): Improve Orchard.Layouts UX with a taller and sticky toolbar, and better scrollbar styling ([#8721](https://github.com/OrchardCMS/Orchard/pull/8721)).
* [#8756](https://github.com/OrchardCMS/Orchard/issues/8756): Add data annotation for proper validation of MenuText length ([#8757](https://github.com/OrchardCMS/Orchard/pull/8757)).
* [#8764](https://github.com/OrchardCMS/Orchard/pull/8764): Update ClickToBuild.cmd to support Visual Studio 2019 and 2022.
* [#8776](https://github.com/OrchardCMS/Orchard/issues/8776): Upgrade Microsoft.CodeDom.Providers.DotNetCompilerPlatform to latest version for Dynamic Compilation, Razor IntelliSense and Razor compilation to work ([#8777](https://github.com/OrchardCMS/Orchard/pull/8777)).
* [#8779](https://github.com/OrchardCMS/Orchard/pull/8779): Recompile client-side assets for 1.10.x branch to update front-end resources.
* [#8803](https://github.com/OrchardCMS/Orchard/issues/8803): Move embed video import logic in the Media Library to a dedicated service for better maintainability ([#8827](https://github.com/OrchardCMS/Orchard/pull/8827)).
* [#8805](https://github.com/OrchardCMS/Orchard/pull/8805): Add validation for internal page links in LinkField to prevent broken navigation.
* [#8808](https://github.com/OrchardCMS/Orchard/issues/8808): Fix Container admin navigation for better usability of items with ContainerPart ([#8809](https://github.com/OrchardCMS/Orchard/pull/8809)).
* [#8811](https://github.com/OrchardCMS/Orchard/issues/8811): Update and consolidate vulnerable NuGet packages (System.IdentityModel.Tokens.Jwt and its dependencies, Newtonsoft.Json, DotNetZip removed) for security ([#8812](https://github.com/OrchardCMS/Orchard/pull/8812)).
* [#8823](https://github.com/OrchardCMS/Orchard/pull/8823): Upgrade MailKit to version 4.9.0 and consolidate NuGet packages for better maintainability and security.

## Bugfixes

* [#6802](https://github.com/OrchardCMS/Orchard/issues/6802): Prevent renaming Media Library files to reserved Windows names ([#6919](https://github.com/OrchardCMS/Orchard/pull/6919)).
* [#6931](https://github.com/OrchardCMS/Orchard/pull/6931): Fixed that getting other localizations of a content item might return nothing.
* [#6962](https://github.com/OrchardCMS/Orchard/issues/6962): Strip the tenant/site `UrlPrefix` from placement path conditions ([#8222](https://github.com/OrchardCMS/Orchard/pull/8222)).
* [#7919](https://github.com/OrchardCMS/Orchard/issues/7919): Fix Alias UI links for sites using UrlPrefix to ensure correct navigation ([#7930](https://github.com/OrchardCMS/Orchard/pull/7930)).
* [#7928](https://github.com/OrchardCMS/Orchard/issues/7928): Fixed failure to convert underscores to dashes in `ItemDisplayLink` ([#8337](https://github.com/OrchardCMS/Orchard/pull/8337)).
* [#8176](https://github.com/OrchardCMS/Orchard/issues/8176): Ensure the correct resource key is used in debug mode so `Script.Include` and `Style.Include` register unique keys for unbundled assets ([#8177](https://github.com/OrchardCMS/Orchard/pull/8177)).
* [#8181](https://github.com/OrchardCMS/Orchard/issues/8181): Preserve wrappers and alternates when updating placement info in `ContentTypePlacementStrategy` to avoid losing original `placement.info` data ([#8182](https://github.com/OrchardCMS/Orchard/pull/)).
* [#8184](https://github.com/OrchardCMS/Orchard/pull/8184): Fix a null reference exception in `DefaultHQLQuery` when evaluating query filters.
* [#8224](https://github.com/OrchardCMS/Orchard/pull/8224): Add redirects for overridden routes in `AdminController` and `ItemController` to ensure proper navigation after route changes.
* [#8247](https://github.com/OrchardCMS/Orchard/issues/8247): Fixing that `ContentPickerField` should keep the selected items selected after changing page ([#8248](https://github.com/OrchardCMS/Orchard/pull/8248)).
* [#8254](https://github.com/OrchardCMS/Orchard/issues/8254): Modify `CreateRouteValues` when no blog ID is specified to avoid incorrect route generation ([#8255](https://github.com/OrchardCMS/Orchard/pull/8255)).
* [#8270](https://github.com/OrchardCMS/Orchard/issues/8270): Add a null check on the content part when deleting the aliases in Autoroute ([#8271](https://github.com/OrchardCMS/Orchard/pull/8271)).
* [#8276](https://github.com/OrchardCMS/Orchard/issues/8276): Update Npgsql to 4.0.17 and fix PostgreSQL setup issues ([#8810](https://github.com/OrchardCMS/Orchard/pull/8810)).
* [#8291](https://github.com/OrchardCMS/Orchard/issues/8291): Ensure `ReCaptchaPartDriver` always returns a shape ([#8292](https://github.com/OrchardCMS/Orchard/pull/8292)).
* [#8293](https://github.com/OrchardCMS/Orchard/issues/8293): Fixing that FieldIndexPartHandler might throw NullReferenceException ([#8294](https://github.com/OrchardCMS/Orchard/pull/8294)).
* [#8305](https://github.com/OrchardCMS/Orchard/issues/8305): Fixed that Blog Archives should calculate the post count correctly ([#8306](https://github.com/OrchardCMS/Orchard/pull/8306)).
* [#8331](https://github.com/OrchardCMS/Orchard/issues/8331): Fix indexing error in the search indexing pipeline to prevent failures during content updates ([#8335](https://github.com/OrchardCMS/Orchard/pull/8335)).
* [#8348](https://github.com/OrchardCMS/Orchard/issues/8348): Fixed errors occurring during indexing operations ([#8349](https://github.com/OrchardCMS/Orchard/pull/8349)).
* [#8391](https://github.com/OrchardCMS/Orchard/issues/8391): Remove lock from the dictionary when the background task completes to prevent memory leaks in `DistributedLockService` ([#8395](https://github.com/OrchardCMS/Orchard/pull/8395)).
* [#8392](https://github.com/OrchardCMS/Orchard/issues/8392): Fix boolean conversion error in model binding ([#8393](https://github.com/OrchardCMS/Orchard/pull/8393)).
* [#8403](https://github.com/OrchardCMS/Orchard/issues/8403): Fix ContentPickerField script conflict with MediaLibraryPickerField scripts also using sessionStorage ([#8404](https://github.com/OrchardCMS/Orchard/pull/8404)).
* [#8410](https://github.com/OrchardCMS/Orchard/pull/8410): Fix model state exception in the Remember Me feature during login.
* [#8412](https://github.com/OrchardCMS/Orchard/pull/8412): Remove custom changes to model bindings to restore default ASP.NET MVC binding behavior and prevent unexpected side effects.
* [#8413](https://github.com/OrchardCMS/Orchard/pull/8413): Introduce a new version of the Boolean Binder Provider for better model binding.
* [#8414](https://github.com/OrchardCMS/Orchard/issues/8414): Fixed that the State property of LayoutRecord was missing the StringLengthMax attribute ([#8415](https://github.com/OrchardCMS/Orchard/pull/8415)).
* [#8416](https://github.com/OrchardCMS/Orchard/pull/8416): Handle cases where a form sends multiple attempted values to prevent boolean binding errors.
* [#8431](https://github.com/OrchardCMS/Orchard/issues/8431): Fixing Media Library Picker styling so that a long title shouldn't cover the action links ([#8433](https://github.com/OrchardCMS/Orchard/pull/8433)).
* [#8435](https://github.com/OrchardCMS/Orchard/issues/8435): Remove check preventing reassignment of loader delegates in Taxonomy `TermPartHandler` so that `Terms` are correctly computed for the `OnUpdated` handler.
* [#8456](https://github.com/OrchardCMS/Orchard/pull/8456): Fixing styling conflict between the overlay of MediaLibraryPickerField and Layouts.
* [#8461](https://github.com/OrchardCMS/Orchard/pull/8461): Prevent exception when Href is null in link generation.
* [#8469](https://github.com/OrchardCMS/Orchard/issues/8469): Fixing that cached pages couldn't work with forms due to the `RequestVerificationToken` ([#8470](https://github.com/OrchardCMS/Orchard/pull/8470)).
* [#8483](https://github.com/OrchardCMS/Orchard/pull/8483): Fixing that Output Cache should invalidate the cache entry when the content item is unpublished.
* [#8492](https://github.com/OrchardCMS/Orchard/pull/8492): Force enumeration of permissions list when importing roles to ensure proper role setup.
* [#8499](https://github.com/OrchardCMS/Orchard/pull/8499): Remove whitespace when importing permissions to avoid parsing errors.
* [#8511](https://github.com/OrchardCMS/Orchard/pull/8511): Add null checks when importing ProjectionPartSettings to prevent runtime errors.
* [#8514](https://github.com/OrchardCMS/Orchard/issues/8514): Fixing edit link for Menu and Projection Query Layout ([#8515](https://github.com/OrchardCMS/Orchard/pull/8515)).
* [#8533](https://github.com/OrchardCMS/Orchard/issues/8533): Fix Widget Element behavior to correctly update the container of widgets during layout changes ([#8534](https://github.com/OrchardCMS/Orchard/pull/8534)).
* [#8540](https://github.com/OrchardCMS/Orchard/issues/8540): Fixed that a TemplateFilterForPart without specifying a group ID renders the shape everywhere ([#8543](https://github.com/OrchardCMS/Orchard/pull/8543)).
* [#8544](https://github.com/OrchardCMS/Orchard/issues/8544): Fixed that TinyMCE only worked with items edited through a custom controller, but not when a TextField with HTML flavor was attached ([#8546](https://github.com/OrchardCMS/Orchard/pull/8546)).
* [#8547](https://github.com/OrchardCMS/Orchard/pull/8547): Fix bug in Media Library plugin to restore expected functionality of computing the Admin URL.
* [#8552](https://github.com/OrchardCMS/Orchard/issues/8552): Added missing minified CSS and JS files to Orchard.Blogs ([#8553](https://github.com/OrchardCMS/Orchard/pull/8553)).
* [#8559](https://github.com/OrchardCMS/Orchard/issues/8559): Move ShapeTracing JavaScript includes to the head for better debugging performance ([#8560](https://github.com/OrchardCMS/Orchard/pull/8560)).
* [#8598](https://github.com/OrchardCMS/Orchard/pull/8598): Create unique HTML element IDs for boolean fields to avoid conflicts.
* [#8602](https://github.com/OrchardCMS/Orchard/issues/8602): Fix profile path length issues when processing images to prevent errors ([#8603](https://github.com/OrchardCMS/Orchard/pull/8603)).
* [#8631](https://github.com/OrchardCMS/Orchard/issues/8631): Fixing that not including a field value in the recipe when importing an item should not reset the field's value ([#8632](https://github.com/OrchardCMS/Orchard/pull/8632)).
* [#8643](https://github.com/OrchardCMS/Orchard/issues/8643): Validate page parameter to ensure an integer value is provided ([#8644](https://github.com/OrchardCMS/Orchard/pull/8644)).
* [#8645](https://github.com/OrchardCMS/Orchard/issues/8645): Validate culture code before applying localization settings ([#8646](https://github.com/OrchardCMS/Orchard/pull/8646)).
* [#8652](https://github.com/OrchardCMS/Orchard/issues/8652): When adding a ContentMenuItem to a Menu, checking that the item is published ([#8653](https://github.com/OrchardCMS/Orchard/pull/8653)).
* [#8656](https://github.com/OrchardCMS/Orchard/pull/8656): Fix email confirmation failure on repeated confirmation attempts.
* [#8659](https://github.com/OrchardCMS/Orchard/pull/8659): Correct RoleEvent actions to match workflow activity outcomes.
* [#8681](https://github.com/OrchardCMS/Orchard/issues/8681): Fix mapping of records in nested namespaces to prevent ORM errors during data persistence ([#8682](https://github.com/OrchardCMS/Orchard/pull/8682)).
* [#8694](https://github.com/OrchardCMS/Orchard/pull/8694): Fixing that the `Orchard.Recipes` feature should depend on `PackagingServices`.
* [#8697](https://github.com/OrchardCMS/Orchard/issues/8697): Add lock on MD5 variable during feature list generation to prevent concurrency issues in multi-threaded environments ([#8697](https://github.com/OrchardCMS/Orchard/pull/8697)).
* [#8703](https://github.com/OrchardCMS/Orchard/pull/8703): Fixing that the field settings for the ContentLink TinyMCE were not persisted.
* [#8712](https://github.com/OrchardCMS/Orchard/issues/8712): Implement scale filter in media processing to avoid grainy images ([#8713](https://github.com/OrchardCMS/Orchard/pull/8713)).
* [#8714](https://github.com/OrchardCMS/Orchard/issues/8714): Update SslSettingsPartHandler to invalidate the cached settings when updating them ([#8715](https://github.com/OrchardCMS/Orchard/pull/8715)).
* [#8722](https://github.com/OrchardCMS/Orchard/issues/8722): Fixing that GetCultureByName in Localization shouldn't throw error if the culture name is null ([#8723](https://github.com/OrchardCMS/Orchard/pull/8723)).
* [#8724](https://github.com/OrchardCMS/Orchard/issues/8724): Use content item's Content Manager for lazy field loading instead of injected instance in ContentPickerField and MediaLibraryPickerField ([#8725](https://github.com/OrchardCMS/Orchard/pull/8725)).
* [#8727](https://github.com/OrchardCMS/Orchard/pull/8727): Prevent TermsFilter from processing empty strings to avoid unnecessary queries.
* [#8734](https://github.com/OrchardCMS/Orchard/pull/8734): Make MailKit upgrade backward compatible with previous SmtpClient configurations.
* [#8738](https://github.com/OrchardCMS/Orchard/pull/8738): Fixed unsupported self-closing div tags in Media Library templates.
* [#8742](https://github.com/OrchardCMS/Orchard/issues/8742): Compare similar paths ignoring casing for consistent routing behavior in Autoroute ([#8743](https://github.com/OrchardCMS/Orchard/pull/8743)).
* [#8745](https://github.com/OrchardCMS/Orchard/issues/8745): Apply corrections to media resizing process not to process items it can't resize ([#8762](https://github.com/OrchardCMS/Orchard/pull/8762)).
* [#8760](https://github.com/OrchardCMS/Orchard/issues/8760): Use content item's Content Manager for lazy field loading to improve consistency for Taxonomy Terms ([#8761](https://github.com/OrchardCMS/Orchard/pull/8761)).
* [#8763](https://github.com/OrchardCMS/Orchard/pull/8763): Fix index out of bounds error when chaining ContentPickerField tokens.
* [#8766](https://github.com/OrchardCMS/Orchard/issues/8766): Access TermsPart.Record before delegate execution to avoid disposed lifetime scope issues ([#8766](https://github.com/OrchardCMS/Orchard/pull/8766)).
* [#8830](https://github.com/OrchardCMS/Orchard/issues/8830): Fix issue where fields attached to a Menu Item were not updated ([#8844](https://github.com/OrchardCMS/Orchard/pull/8844)).
* [#8845](https://github.com/OrchardCMS/Orchard/pull/8845): Prevent Indexing AdminController and Commands from using unsafe index names.

## Continuous Integration

* [#8686](https://github.com/OrchardCMS/Orchard/issues/8686): Fix build and tests on 1.10.x branch for compatibility ([#8687](https://github.com/OrchardCMS/Orchard/pull/8687)).
* [#8816](https://github.com/OrchardCMS/Orchard/issues/8816): Compilation workflow now tests the setup and Code Generation too ([#8817](https://github.com/OrchardCMS/Orchard/pull/8817)).
* [#8819](https://github.com/OrchardCMS/Orchard/issues/8819): Compile workflow not runs a basic SpecFlow test too to ensure the test app isn't broken ([#8820](https://github.com/OrchardCMS/Orchard/pull/8820)).
* [#8841](https://github.com/OrchardCMS/Orchard/pull/8841): Fix gulp pipeline installation and improve error detection.
* [#8843](https://github.com/OrchardCMS/Orchard/pull/8843): Running workflows on Windows-2025 runners.

## Contributors

### First-time Contributors

* [MobesE46](https://github.com/MobesE46) in [#6610](https://github.com/OrchardCMS/Orchard/pull/6610).
* [eszterkoczak](https://github.com/eszterkoczak) in [#8210](https://github.com/OrchardCMS/Orchard/pull/8210).
* [imranazad](https://github.com/imranazad) in [#8395](https://github.com/OrchardCMS/Orchard/pull/8395).
* [dministro](https://github.com/dministro) in [#8707](https://github.com/OrchardCMS/Orchard/pull/8707).
* [luciofassio](https://github.com/luciofassio) in [#8713](https://github.com/OrchardCMS/Orchard/pull/8713).
* [RichieOrtiz](https://github.com/RichieOrtiz) in [#8717](https://github.com/OrchardCMS/Orchard/pull/8717).
* [dmhiggins23](https://github.com/dmhiggins23) in [#8764](https://github.com/OrchardCMS/Orchard/pull/8764).

### Repeat Contributors

* [AgostiniAlessandro](https://github.com/AgostiniAlessandro)
* [aipetryakov](https://github.com/aipetryakov)
* [AndreaPiovanelli](https://github.com/AndreaPiovanelli)
* [andrewcartwright1](https://github.com/andrewcartwright1)
* [BenedekFarkas](https://github.com/BenedekFarkas)
* [diegomarguerettaz](https://github.com/diegomarguerettaz)
* [ElenaRepository](https://github.com/ElenaRepository)
* [GiuseppeMusso-Laser](https://github.com/GiuseppeMusso-Laser)
* [Hazzamanic](https://github.com/Hazzamanic)
* [HermesSbicego-Laser](https://github.com/HermesSbicego-Laser)
* [jchenga](https://github.com/jchenga)
* [jersiovic](https://github.com/jersiovic)
* [LorenzoFrediani-Laser](https://github.com/LorenzoFrediani-Laser)
* [MarcoViglione-Laser](https://github.com/MarcoViglione-Laser)
* [MatteoPiovanelli](https://github.com/MatteoPiovanelli)
* [MpDzik](https://github.com/MpDzik)
* [sebastienros](https://github.com/sebastienros)
* [TFleury](https://github.com/TFleury)

## How to upgrade from a previous version

You can find [migration instructions here](https://docs.orchardproject.net/Documentation/Upgrading-a-site-to-a-new-version-of-Orchard).
