﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManagement.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManagement.Gallery
{
    /// <summary>
    /// Get one template or a list of templates from the gallery.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureResourceGroupGalleryTemplate"), OutputType(typeof(bool))]
    public class GetAzureResourceGroupGalleryTemplateCommand : ResourceBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Name of the template.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Category of the template.")]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Publisher of the template.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Country of the template.")]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Category = Category,
                Country = Country,
                Name = Name,
                Publisher = Publisher
            };

            WriteObject(ResourceClient.FilterGalleryTemplates(options), true);
        }
    }
}
