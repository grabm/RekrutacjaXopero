using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaXopero.Logic.Modules.GitLab.Models;

public record GitLabCreateIssue(
    string ProjectId,
    string Title,
    string Description);